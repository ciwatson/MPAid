@Echo OFF
REM	****************************
REM	This batch file is used to generate train code script (Script.scp) and the MFC files associated with audio recordings
REM	****************************

REM	****************************
REM     if the folder "HMMs" does not exist, Create one
REM	****************************

IF NOT EXIST "%cd%\..\HMMs\" (mkdir "%cd%\..\HMMs\")

REM	****************************
REM	set up the environment varibles 
REM	****************************

pushd "%cd%"
cd ..
for /f %%i in ('dir "%cd%" /a:d /b /d') do (
  IF NOT DEFINED %%i (
	set %%i=%cd%\%%i\
  )
)
popd

REM	****************************
REM     Generate train script in %HMMs% from %MFCs%
REM	****************************
Perl MFCs2Script.pl "%MFCs%\" mfc "%cd%"

REM	****************************
REM	assign character set to utf-8
REM	****************************
REM     chcp 65001 >NUL

REM	****************************
REM	make hmm0
REM	****************************
REM if not exist hmm0 (mkdir hmm0)
REM "%Tools%HCompV" -C config1 -f 0.01 -m -S Train.scp -M hmm0 prot

REM	****************************
REM	make hmm1-3 based on hmm0
REM	****************************
if not exist hmm1 (mkdir hmm1)
"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF0.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm0/macros -H hmm0/hmmdefs -M hmm1 "%Dictionaries%monophones0"

if not exist hmm2 (mkdir hmm2)
"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF0.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm1/macros -H hmm1/hmmdefs -M hmm2 "%Dictionaries%monophones0"

if not exist hmm3 (mkdir hmm3)
"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF0.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm2/macros -H hmm2/hmmdefs -M hmm3 "%Dictionaries%monophones0"

REM	****************************
REM	make hmm5-7 based on sil.hed
REM	****************************
if not exist hmm5 (mkdir hmm5)
"%Tools%HHEd" -H hmm4/macros -H hmm4/hmmdefs -M hmm5 sil.hed "%Dictionaries%monophones1"

if not exist hmm6 (mkdir hmm6)
"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF1.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm5/macros -H hmm5/hmmdefs -M hmm6 "%Dictionaries%monophones1"

if not exist hmm7 (mkdir hmm7)
"%Tools%HERest" -C config1 -I "%MLFs%PhoneMLF1.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm6/macros -H hmm6/hmmdefs -M hmm7 "%Dictionaries%monophones1"

REM	****************************
REM	Re-aligning the training data 
REM	****************************
"%Tools%HVite" -l * -o SWT -b SENT-END -C config1 -a -H hmm7/macros -H hmm7/hmmdefs -i "%MLFs%AlignedMLF.mlf" -m -t 250.0 150.0 1000.0 -y lab -I "%MLFs%WordMLF.mlf" -S train.scp "%Dictionaries%dictionary" "%Dictionaries%monophones1"> HVite.log

REM	****************************
REM	make hmm8-9 based on a %MLFs%AlignedMLF.mlf
REM	****************************
if not exist hmm8 (mkdir hmm8)
"%Tools%HERest" -C config1 -I "%MLFs%AlignedMLF.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm7/macros -H hmm7/hmmdefs -M hmm8 "%Dictionaries%monophones1"

if not exist hmm9 (mkdir hmm9)
"%Tools%HERest" -C config1 -I "%MLFs%AlignedMLF.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm8/macros -H hmm8/hmmdefs -M hmm9 "%Dictionaries%monophones1"

REM	****************************
REM	make hmm10
REM	****************************
"%Tools%HLEd" -n triphones1 -l * -i "%MLFs%TriphoneMLF.mlf" "%Params%mktri.led" "%MLFs%AlignedMLF.mlf"

Perl maketrihed.pl "%Dictionaries%monophones1" triphones1

if not exist hmm10 (mkdir hmm10)
"%Tools%HHEd" -H hmm9/macros -H hmm9/hmmdefs -M hmm10 mktri.hed "%Dictionaries%monophones1"

REM	****************************
REM	make hmm11-12, as well as statistic file stats
REM	****************************
if not exist hmm11 (mkdir hmm11)
"%Tools%HERest" -C config1 -I "%MLFS%triphoneMLF.mlf" -t 250.0 150.0 1000.0 -S train.scp -H hmm10/macros -H hmm10/hmmdefs -M hmm11 triphones1 

if not exist hmm12 (mkdir hmm12)
"%Tools%HERest" -C config1 -I "%MLFS%triphoneMLF.mlf" -t 250.0 150.0 1000.0 -s stats -S train.scp -H hmm11/macros -H hmm11/hmmdefs -M hmm12 triphones1

"%Tools%HDMan" -b sp -n "%Dictionaries%FullPhoneList" -g "%Params%mktriphones.ded" -l HDMan.Log "%Dictionaries%tri-dictionary" "%Dictionaries%lexicon.txt"

type NUL > "%Dictionaries%FullPhoneListAdded"
type "%Dictionaries%monophones0" >> "%Dictionaries%FullPhoneListAdded"
type "%Dictionaries%FullPhoneList" >> "%Dictionaries%FullPhoneListAdded"
Perl MergeFullPhoneList.pl "%Dictionaries%FullPhoneListAdded" FullPhoneListMerged

REM	****************************
REM	make hmm13-15
REM	****************************
if not exist hmm13 (mkdir hmm13)
"%Tools%HHEd" -H hmm12/macros -H hmm12/hmmdefs -M hmm13 "%Params%tree.hed" triphones1

if not exist hmm14 (mkdir hmm14)
"%Tools%HERest" -C config1 -I "%MLFS%triphoneMLF.mlf"  -t 250.0 150.0 3000.0 -S train.scp -H hmm13/macros -H hmm13/hmmdefs -M hmm14 tiedlist

if not exist hmm15 (mkdir hmm15)
"%Tools%HERest" -C config1 -I "%MLFS%triphoneMLF.mlf"  -t 250.0 150.0 3000.0 -S train.scp -H hmm14/macros -H hmm14/hmmdefs -M hmm15 tiedlist

pause&exit