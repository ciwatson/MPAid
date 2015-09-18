REM	****************************
REM	INTRO: GO_V3_ANNIE_part1.BAT
REM	****************************
REM	This is a batch file used to prepare data and for training the HMMs. It has been editted from Sam and Byron's previous versions, go_v1_sam.bat and go_v2_byron.bat.
REM	Note that anything preceded by 'REM' will not be performed by the computer/commented out.

REM	As some files need to be manually prepared/editted, it is suggested that you read the 'QuickStart.txt' file, 'HTK Tut Annie.docx', the HTKBook chapter 3, the voxforge tutorial:
REM			http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial
REM	and this batch file fully before proceeding.

REM	 Good luck!						-Annie <23/01/2012>





REM	****************************
REM	INITIALISATION
REM	****************************
REM	make files for each of the hmms and put in file HMM.
mkdir HMMs
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





REM	****************************
rem	DATA PREPARATION
REM	****************************
REM	<3.1.1>CREATE a 'wordNetwork' in 'user' from a manually created 'grammer' file stored in 'user'
HParse user/grammer user/wordNetwork
REM	<3.1.2>Create 'dictionary' and 'monophones1' manually as we do not have a pronunciation dictionary and cannot use command HDMan
REM	<3.1.3>Record training and testing data using HSGen
REM	<3.1.4>Create a word level transcription file manually, called wordTranscript.mlf (refer to Byron's note QuickStart.txt)
REM	<3.1.4>then use HLed to create phone level transcriptions
HLEd -l * -d user/dictionary -i user/phoneTranscipt0.mlf user/mkphones0EditScript4HLEd.led user/wordTranscript.mlf
HLEd -l * -d user/dictionary -i user/phoneTranscript1.mlf user/mkphones1EditScript4HLEd.led user/wordTranscript.mlf
REM	<3.1.5>Coding the Audio Data. First, modify the codeTrain and codeTest script files 
REM	<3.1.5>to include the full path of the training and testing files saved in 'train' and 'test' (in 'htk') on your computer.
REM	<3.1.5>May face 32 bit 64 bit issues. Use 64-bit OS.
HCopy -T 1 -C user/config0 -S user/codeTrain.scp
HCopy -T 1 -C user/config0 -S user/codeTestL1YoungMale.scp
REM	<3.1.5> HCopy -T 1 -C user/config0 -S user/codeTestL1YoungFemale.scp





REM	****************************
REM	HMM TRAINING
REM	****************************
REM	<3.2.1>Creating flat start monophones
REM	<3.2.1> Create train.scp in user. Check initial proto file in user matches config1. Will face 32/64 bit problem again.
HCompV -C user/config1 -f 0.01 -m -S user/train.scp -M hmm0 user/proto
SCopy	REM	<3.2.1>this creates the hmmdefs and macros file in hmm0
REM	<3.2.1> Re-estimate monophone models
HERest -C user/config1 -I user/phoneTranscript0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm0/macros -H hmm0/hmmdefs -M hmm1 user/monophones0
HERest -C user/config1 -I user/phoneTranscript0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm1/macros -H hmm1/hmmdefs -M hmm2 user/monophones0
HERest -C user/config1 -I user/phoneTranscript0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm2/macros -H hmm2/hmmdefs -M hmm3 user/monophones0
copy hmm3\hmmdefs hmm4\hmmdefs
REM	Edit hmmdefs in hmm4 to have a 'sp' model as seen in  the voxforge tutorial 'fixing silence models' section. Go to 'go_v3_annie_part2'.




