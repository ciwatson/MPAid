**************************** MFAP README ****************************

This is the readme file on how to use this collection of programs!





To begin, I will give a brief run down of the software architecture.  Following that will be an explanation of how to use the program, and then of what you need to do to make it work.



Of the programs included in this package, HCompV, HCopy, HERest, HHEd, HLEd, HParse and HVite are part of the HTK toolkit.  SCopy and SPCopy are additional programs created to simplify the process of creating hidden markov models.

Each program is a stand alone module that performs a task based on the inputs given to it.  These tasks are outlined in the htk book, which can be downloaded from the htk website:

http://htk.eng.cam.ac.uk/

Some require specific inputs, others can very.  SPCopy and SCopy do not require inputs, they will run of their own accord.  However, to do this, the correct file names must be used!  Therefore I would suggest you keep the same file names in the 'user' directory.


THE USER DIRECTORY


The user directory is so named because it contains all the files that I would recommend the user modifies.  Some are definitely to be modified, others are not.

I will give a brief run down of what each one does (in alphabetical order):


codetr.scp:   This is a script file used to tell the program to create 'mel frequency coefficients' for each recording you are using to train the system.  It is a simple file - on one line it has the source wave file, followed by the 'coded' file that will come out.  There needs to be one line for each wave file you are using to train.  I would recommend you retain the directories used in this, changing the first few to the correct directory on your computer.

codettest.scp:  This is a script file used to do exactly the same thing as the previous script file.  However, these are the 'test' files, not the 'train' files.  Therefore, these are the files you want to perform forced alignment on.

config0/config1/config2:  A config script for parameter estimation.  I would not advise changing this without consulting the HTK book thoroughly.

dict:  This is a dictionary file of ALL the words you would ever like to recognise.  It is highly recommended that this is update to include every word in the language.  However, it also has a strict format that needs to be adhered to.  The HTK book has a small amount of information in it - I would recommend consulting that before changing this.  NOTE:  This file MUST contain all the words needed for training and testing.  It simply cannot be incomplete.

gram:  This is the file that notates the 'grammar' used for speech recognition.  It is not necessary at this time, but may be for future uses.  (At the moment, we use label files to help the transcription.  If we didn't want to, we would have to use the 'wdnet' (word net) file that is a direct descendent of the gram file).  This hasn't been implemented due to the fact that ANY grammar could be used... therefore, this file would have to be an endless repetition of possible words.

mkphones.led:  This is a configuration file that tells the program what to do in a certain step - refer to the htk book for more detail!  I would not recommend changing this.

mktri.hed:  This is a configuration file that tells the program what to do in a certain step - refer to the htk book for more detail!  I would not recommend changing this.  However, this needs to be updated for every phoneme you use - if you change the phoneme list in monophones0 or monophones1, you must change this file as well.

mktri.led:  This is a configuration file that tells the program what to do in a certain step - refer to the htk book for more detail!  I would not recommend changing this.

monophones0:  This is a list of all the phonemes in the language.  This needs to be changed if you are using a different language, or are updating based on new research.  This is an EXTREMELY important file - it is used in almost every step.

monophones1:  This is exactly the same as monophones0, except it includes the 'sp' or 'short pause' model.

proto:  This is the definition for the prototype hidden markov model.  I would not recommend changing this.

sil.hed:  This is a configuration file that tells the program what to do in a certain step - refer to the htk book for more detail!  I would not recommend changing this.

test.scp:  This is a list of the CODED files that you would like to perform forced alignment on.

train.scp:  This is a list of the CODED files that you would like to train the system.

words.mlf:  This is the MASTER LABEL FILE for the files you wish to train the system on.  It is important that this format is strictly adhered to.




Okay, that's the list of all the files I recommend modifying.  There is only one last file to discuss:


THE BATCH FILE

The batch file 'go' is essentially the master program for forced alignment.  Currently it will train the hidden markov models based on the files described in the train.scp file, and will then perform forced alignment on the files described in the test.scp file.



As always, the htk book should be consulted if you wish to modify anything other than the basics!

