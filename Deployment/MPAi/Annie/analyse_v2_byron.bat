HCopy -T 1 -C user/config0 -S user/codettest.scp
HVite -a -o NW -m -C user/config1 -H hmm40/macros -H hmm40/hmmdefs -S user/test.scp -l * -i analysisresults.mlf -p 0.0 -s 5.0 -y lab -I user/words.mlf user/dict user/monophones1
HResults -I user/words.mlf user/monophones1 analysisresults.mlf