REM	****************************
REM	INTRO: GO_V3_ANNIE_part3.BAT
REM	****************************
REM	This is a batch file used to prepare data and for training the HMMs. It has been editted from Sam and Byron's previous versions, go_v1_sam.bat and go_v2_byron.bat.
REM	Note that anything preceded by 'REM' will not be performed by the computer/commented out.

REM	As some files need to be manually prepared/editted, it is suggested that you read the 'QuickStart.txt' file, 'HTK Tut Annie.docx', the HTKBook chapter 3, the voxforge tutorial:
REM			http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial
REM	and this batch file fully before proceeding.

REM	 Good luck!						-Annie <23/01/2012>





REM	***************************
REM	TRIPHONE CREATION CONT.
REM	***************************
REM	Copy fullPhoneList and Triphones1 into a new file called fullPhoneList1. Go to 'go_v3_annie_part3.bat.
REM	<3.3.2>
perl fixFullList.pl user/fullPhoneList1 user/fullPhoneList2
HHEd -H hmm12/macros -H hmm12/hmmdefs -M hmm13 user/tree.hed user/triphones1
HERest -C user/config1 -I user/triphoneTranscriptWINTRI.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm13/macros -H hmm13/hmmdefs -M hmm14 user/tiedList
HERest -C user/config1 -I user/triphoneTranscriptWINTRI.mlf -t 250.0 150.0 1000.0 -S user/train.scp -H hmm14/macros -H hmm14/hmmdefs -M hmm15 user/tiedList





REM	***************************
REM	CLEANUP
REM	***************************
move hmm0 HMMs
move hmm1 HMMs
move hmm2 HMMs
move hmm3 HMMs
move hmm4 HMMs
move hmm5 HMMs
move hmm6 HMMs
move hmm7 HMMs
move hmm8 HMMs
move hmm9 HMMs
move hmm10 HMMs
move hmm11 HMMs
move hmm12 HMMs
move hmm13 HMMs
move hmm14 HMMs
move hmm15 HMMs
