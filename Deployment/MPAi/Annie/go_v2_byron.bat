REM	****************************
REM	INTRO
REM	****************************

REM	As this is a batch file, anything preceded by 'REM' will not be performed by the computer.  This is how to comment in batch file format :)

REM	Currently the triphone creation is disabled, but that shouldn't be a big worry.  As it is, there is no reason to modify this file past the monophone stage, as triphones are used primarily for recognition.


REM	****************************
REM	INITIALISATION
REM	****************************


mkdir mfcs
mkdir hmm0
mkdir hmm1
mkdir hmm2
mkdir hmm3
mkdir hmm4
mkdir hmm5
mkdir hmm6
mkdir hmm7
mkdir hmm8
mkdir hmm9
mkdir hmm10
mkdir hmm11
mkdir hmm12
mkdir hmm13
mkdir hmm14
mkdir hmm15
mkdir hmm16
mkdir hmm17
mkdir hmm18
mkdir hmm19
mkdir hmm20
mkdir hmm21
mkdir hmm22
mkdir hmm23
mkdir hmm24
mkdir hmm25
mkdir hmm26
mkdir hmm27
mkdir hmm28
mkdir hmm29
mkdir hmm30
mkdir hmm31
mkdir hmm32
mkdir hmm33
mkdir hmm34
mkdir hmm35
mkdir hmm36
mkdir hmm37
mkdir hmm38
mkdir hmm39
mkdir hmm40

HParse user/gram wdnet
HLEd -l * -d user/dict -i phones0.mlf user/mkphones.led user/words.mlf
HCopy -T 1 -C user/config0 -S user/codetr.scp
HCopy -T 1 -C user/config0 -S user/codettest.scp


REM	****************************
REM	HMM TRAINING
REM	****************************


HCompV -C user/config1 -f 0.01 -m -S user/train.scp -M hmm0 user/proto

SCopy

HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm0/macros -H hmm0/hmmdefs -M hmm1 user/monophones0
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm1/macros -H hmm1/hmmdefs -M hmm2 user/monophones0
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm2/macros -H hmm2/hmmdefs -M hmm3 user/monophones0

Spcopy

copy hmm3\macros hmm4\macros

HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm4/macros -H hmm4/hmmdefs -M hmm5 user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm5/macros -H hmm5/hmmdefs -M hmm6 user/monophones1
HVite -l * -o SWT -b silence -C user/config1 -a -H hmm6/macros -H hmm6/hmmdefs -i aligned.mlf -m -t 1000.0 -y lab -I user/words.mlf -S user/train.scp user/dict user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm6/macros -H hmm6/hmmdefs -M hmm7 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm7/macros -H hmm7/hmmdefs -M hmm8 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm8/macros -H hmm8/hmmdefs -M hmm9 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm9/macros -H hmm9/hmmdefs -M hmm10 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm10/macros -H hmm10/hmmdefs -M hmm11 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm11/macros -H hmm11/hmmdefs -M hmm12 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm12/macros -H hmm12/hmmdefs -M hmm13 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm13/macros -H hmm13/hmmdefs -M hmm14 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm14/macros -H hmm14/hmmdefs -M hmm15 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm15/macros -H hmm15/hmmdefs -M hmm16 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm16/macros -H hmm16/hmmdefs -M hmm17 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm17/macros -H hmm17/hmmdefs -M hmm18 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm18/macros -H hmm18/hmmdefs -M hmm19 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm19/macros -H hmm19/hmmdefs -M hmm20 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm20/macros -H hmm20/hmmdefs -M hmm21 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm21/macros -H hmm21/hmmdefs -M hmm22 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm22/macros -H hmm22/hmmdefs -M hmm23 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm23/macros -H hmm23/hmmdefs -M hmm24 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm24/macros -H hmm24/hmmdefs -M hmm25 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm25/macros -H hmm25/hmmdefs -M hmm26 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm26/macros -H hmm26/hmmdefs -M hmm27 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm27/macros -H hmm27/hmmdefs -M hmm28 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm28/macros -H hmm28/hmmdefs -M hmm29 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm29/macros -H hmm29/hmmdefs -M hmm30 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm30/macros -H hmm30/hmmdefs -M hmm31 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm31/macros -H hmm31/hmmdefs -M hmm32 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm32/macros -H hmm32/hmmdefs -M hmm33 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm33/macros -H hmm33/hmmdefs -M hmm34 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm34/macros -H hmm34/hmmdefs -M hmm35 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm35/macros -H hmm35/hmmdefs -M hmm36 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm36/macros -H hmm36/hmmdefs -M hmm37 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm37/macros -H hmm37/hmmdefs -M hmm38 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm38/macros -H hmm38/hmmdefs -M hmm39 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm39/macros -H hmm39/hmmdefs -M hmm40 user/monophones1



REM	****************************
REM	CURRENTLY INACTIVE - NEW SECTION ABOVE
REM	****************************

HHEd -H hmm4/macros -H hmm4/hmmdefs -M hmm5 user/sil.hed user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm5/macros -H hmm5/hmmdefs -M hmm6 user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm6/macros -H hmm6/hmmdefs -M hmm7 user/monophones1
HVite -l * -o SWT -b silence -C user/config1 -a -H hmm7/macros -H hmm7/hmmdefs -i aligned.mlf -m -t 1000.0 -y lab -I user/words.mlf -S user/train.scp user/dict user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm7/macros -H hmm7/hmmdefs -M hmm8 user/monophones1
HERest -C user/config1 -I aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm8/macros -H hmm8/hmmdefs -M hmm9 user/monophones1



REM	****************************
REM	TRIPHONE CREATION SECTION
REM	(currently disabled)
REM	****************************



HLEd -n triphones1 -l * -i wintri.mlf user/mktri.led aligned.mlf

HHEd -B -H hmm9/macros -H hmm9/hmmdefs -M hmm10 user/mktri.hed user/monophones1

HERest -B -C user/config1 -I wintri.mlf -t 250.0 150.0 1000.0 -s stats -S user/train.scp -H hmm10/macros -H hmm10/hmmdefs -M hmm11 triphones1

HERest -B -C user/config1 -I wintri.mlf -t 250.0 150.0 1000.0 -s stats -S user/train.scp -H hmm11/macros -H hmm11/hmmdefs -M hmm12 triphones1


REM	***************************
REM	FORCED ALIGNMENT SECTION
REM	***************************

HVite -b silence -a -o NW -m -C user/config1 -H hmm40/macros -H hmm40/hmmdefs -S user/test.scp -l * -i results.mlf -p 0.0 -s 5.0 -y lab -I user/words.mlf user/dict user/monophones1


REM	***************************
REM	LABEL CONVERTER TO EMU
REM	***************************

LabCon2
REM LabCon

REM	***************************
REM	Byron
REM	***************************

HCopy -T 1 -C user/config0 -S user/codettest.scp
HVite -a -o NW -m -C user/config1 -H hmm40/macros -H hmm40/hmmdefs -S user/test.scp -l * -i test.mlf -p 0.0 -s 5.0 -y lab -I user/words.mlf user/dict user/monophones1
HResults -I user/words.mlf user/monophones1 test.mlf

REM	***************************
REM	CLEANUP - removing files
REM	***************************



erase hmm0 /S /Q
erase hmm1 /S /Q
erase hmm2 /S /Q
erase hmm3 /S /Q
erase hmm4 /S /Q
erase hmm5 /S /Q
erase hmm6 /S /Q
erase hmm7 /S /Q
erase hmm8 /S /Q
erase hmm9 /S /Q
erase hmm10 /S /Q
erase hmm11 /S /Q
erase hmm12 /S /Q
erase mfcs /S /Q

rd hmm0 /Q
rd hmm1 /Q
rd hmm2 /Q
rd hmm3 /Q
rd hmm4 /Q
rd hmm5 /Q
rd hmm6 /Q
rd hmm7 /Q
rd hmm8 /Q
rd hmm9 /Q
rd hmm10 /Q
rd hmm11 /Q
rd hmm12 /Q
rd mfcs /Q

erase aligned.mlf
erase wintri.mlf
erase phones0.mlf
erase stats
erase triphones1
erase wdnet

REM cls