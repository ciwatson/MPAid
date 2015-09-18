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

HHEd -H hmm4/macros -H hmm4/hmmdefs -M hmm5 user/sil.hed user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm5/macros -H hmm5/hmmdefs -M hmm6 user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm6/macros -H hmm6/hmmdefs -M hmm7 user/monophones1
HVite -l * -o SWT -b silence -C user/config1 -a -H hmm7/macros -H hmm7/hmmdefs -i aligned.mlf -m -t 1000.0 -y lab -I user/words.mlf -S user/train.scp user/dict user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm7/macros -H hmm7/hmmdefs -M hmm8 user/monophones1
HERest -C user/config1 -I phones0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm8/macros -H hmm8/hmmdefs -M hmm9 user/monophones1



REM	****************************
REM	TRIPHONE CREATION SECTION
REM	(currently disabled)
REM	****************************



REM HLEd -n triphones1 -l * -i wintri.mlf user/mktri.led aligned.mlf

REM HHEd -B -H hmm9/macros -H hmm9/hmmdefs -M hmm10 user/mktri.hed user/monophones1

REM HERest -B -C user/config1 -I wintri.mlf -t 250.0 150.0 1000.0 -s stats -S user/train.scp -H hmm10/macros -H hmm10/hmmdefs -M hmm11 triphones1

REM HERest -B -C user/config1 -I wintri.mlf -t 250.0 150.0 1000.0 -s stats -S user/train.scp -H hmm11/macros -H hmm11/hmmdefs -M hmm12 triphones1


REM	***************************
REM	FORCED ALIGNMENT SECTION
REM	***************************

HVite -a -o SW -m -C user/config2 -H hmm9/macros -H hmm9/hmmdefs -S user/test.scp -l * -i results.mlf -p 0.0 -s 5.0 user/dict user/monophones1

REM	***************************
REM	LABEL CONVERTER TO EMU
REM	***************************

LabCon



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