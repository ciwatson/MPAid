echo off
color 0A
title Processing
HCopy -T 1 -C user/config0 -S user/mpaidScript1.scp
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/mpaidScript2.scp -l * -T 4 -i MPAidOutput/mpaid0A.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList > MPAidOutput/mpaidHViteOut
HVite -H -C user/config1 HMMs/hmm15/macros -H HMMs/hmm15/hmmdefs -S user/mpaidScript2.scp -l * -a -f -i MPAidOutput/mpaid0B.mlf -w user/wordNetwork -p 0.0 -s 5.0 user/dictionary user/tiedList
HResults -t -I user/wordTranscript.mlf user/tiedList MPAidOutput/mpaid0A.mlf > MPAidOutput/FinalResult.txt
