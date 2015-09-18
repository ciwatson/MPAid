REM	****************************
REM	INTRO: GO_V3_ANNIE_part2.BAT
REM	****************************
REM	This is a batch file used to prepare data and for training the HMMs. It has been editted from Sam and Byron's previous versions, go_v1_sam.bat and go_v2_byron.bat.
REM	Note that anything preceded by 'REM' will not be performed by the computer/commented out.

REM	As some files need to be manually prepared/editted, it is suggested that you read the 'QuickStart.txt' file, 'HTK Tut Annie.docx', the HTKBook chapter 3, the voxforge tutorial:
REM			http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial
REM	and this batch file fully before proceeding.

REM	 Good luck!						-Annie <23/01/2012>





REM	****************************
REM	HMM TRAINING
REM	****************************
REM	Spcopy	REM	<3.2.2>adding 'sp' model to the hmmdefs file in hmm3, and save in hmm4. Doesn't work. Do this by hand
REM	<3.2.2> Fixing silence models
copy hmm3\macros hmm4\macros
HHEd -H hmm4/macros -H hmm4/hmmdefs -M hmm5 user/sil.hed user/monophones1
HERest -C user/config1 -I user/phoneTranscript0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm5/macros -H hmm5/hmmdefs -M hmm6 user/monophones1
HERest -C user/config1 -I user/phoneTranscript0.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm6/macros -H hmm6/hmmdefs -M hmm7 user/monophones1
REM	<3.2.3> Realigning Training Data
HVite -l * -o SWT -b silence -C user/config1 -a -H hmm7/macros -H hmm7/hmmdefs -i user/aligned.mlf -m -t 250.0 150.0 1000.0 -y lab -I user/wordTranscript.mlf -S user/train.scp user/dictionary user/monophones1
HERest -C user/config1 -I user/aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm7/macros -H hmm7/hmmdefs -M hmm8 user/monophones1
HERest -C user/config1 -I user/aligned.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm8/macros -H hmm8/hmmdefs -M hmm9 user/monophones1





REM	****************************
REM	TRIPHONE CREATION PART 1 
REM	****************************
REM	<3.3.1> Making Triphones from monophones using transcript in aligned.mlf.
REM	<3.3.1> you must make sure you have perl and the file maketrihed
HLEd -n user/triphones1 -l * -i user/triphoneTranscriptWINTRI.mlf user/mktri.led user/aligned.mlf
perl maketrihed user/monophones1 user/triphones1	REM C:\strawberry\perl\bin\perl instead of just perl
copy mktri.hed user\mktri.hed
HHEd -H hmm9/macros -H hmm9/hmmdefs -M hmm10 user/mktri.hed user/monophones1
HERest -C user/config1 -I user/triphoneTranscriptWINTRI.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm10/macros -H hmm10/hmmdefs -M hmm11 user/triphones1
HERest -C user/config1 -I user/triphoneTranscriptWINTRI.mlf -t 250.0 150.0 1000.0 -s user/stats -S user/train.scp -H hmm11/macros -H hmm11/hmmdefs -M hmm12 user/triphones1
REM	<3.3.2> Making tied state triphones
HDMan -b sp -n user/fullPhoneList -g user/global.ded -l user/HDManFLOG user/triphoneDictionary user/lexicon.txt
REM	Copy fullPhoneList and Triphones1 into a new file called fullPhoneList1. Go to 'go_v3_annie_part3.bat.




