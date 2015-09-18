REM	****************************
REM	INTRO: analyse_V3_ANNIE.BAT
REM	****************************
REM	This is a batch file used to analyse recognition data after training using go_v3_annie_part1,2,3.bat.
REM	Note that anything preceded by 'REM' will not be performed by the computer/commented out.

REM	As some files need to be manually prepared/editted, it is suggested that you read the 'QuickStart.txt' file, 'HTK Tut Annie.docx', the HTKBook chapter 3, the voxforge tutorial:
REM			http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/tutorial
REM	and this batch file fully before proceeding.

REM	 Good luck!						-Annie <24/01/2012>




mkdir analysisOutput
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/train.scp -l * -T 4 -i analysisOutput/recout0aTrain.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList>analysisOutput/HViteOut0Train
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/train.scp -l * -a -f -i analysisOutput/recout0bTrain.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList
HResults -t -I user/wordTranscript.mlf user/tiedList analysisOutput/recout0aTrain.mlf>analysisOutput/HResultsOut0Train
REM	inital results using HTK tutorial config testing on training data.
REM	====================== HTK Results Analysis =======================
REM	  Date: Tue Jan 24 15:25:26 2012
REM	  Ref : user/wordTranscript.mlf
REM	  Rec : analysisOutput/recout1.mlf
REM	------------------------ Overall Results --------------------------
REM	SENT: %Correct=77.02 [H=352, S=105, N=457]
REM	WORD: %Corr=78.12, Acc=70.24 [H=357, D=0, S=100, I=36, N=457]
REM	===================================================================
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/testL1YoungMale.scp -l * -T 4 -i analysisOutput/recout1aTestL1Male.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList>analysisOutput/HViteOut1TestL1Male
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/testL1YoungMale.scp -l * -a -f -i analysisOutput/recout1bTestL1Male.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList
HResults -t -I user/testL1YoungMaleWordTranscript.mlf user/tiedList analysisOutput/recout1aTestL1Male.mlf>analysisOutput/HResultsOut1TestL1Male
REM	====================== HTK Results Analysis =======================
REM	  Date: Tue Jan 24 15:38:15 2012
REM	  Ref : user/testL1YoungMaleWordTranscript.mlf
REM	  Rec : analysisOutput/recout1.mlf
REM	------------------------ Overall Results --------------------------
REM	SENT: %Correct=70.59 [H=84, S=35, N=119]
REM	WORD: %Corr=72.27, Acc=60.50 [H=86, D=0, S=33, I=14, N=119]
REM	===================================================================
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/testL1YoungFemale.scp -l * -T 4 -i analysisOutput/recout2aTestL1Female.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList>analysisOutput/HViteOut2TestL1Female
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/testL1YoungFemale.scp -l * -a -f -i analysisOutput/recout2bTestL1Female.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList
HResults -t -I user/testL1YoungFemaleWordTranscript.mlf user/tiedList analysisOutput/recout2aTestL1Female.mlf>analysisOutput/HResultsOut2TestL1Female
