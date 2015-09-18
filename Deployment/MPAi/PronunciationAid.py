from Tkinter import *
from tkSnack import *
import os
import tkMessageBox
import ttk

FRAMEWIDTH = 1100
FRAMEHEIGHT = 580

class PronunciationAid:



    def __init__(self, parent, path, root):

        self.root = root
        self.parent = parent
        self.appDirectory=path
        self.selectedWord = None

        self.setUpWidgets()

        self.initialiseSounds()
        self.updateWord(self.selectedWord)
        self.clearScore()

        self.isRecording=False

    def setUpWidgets(self):
        self.pronunciationPlotFrame = Frame(self.parent,width=FRAMEWIDTH,height=FRAMEHEIGHT)
        self.pronunciationPlotFrame.pack()

        self.recordButton = ttk.Button(self.pronunciationPlotFrame, text='Record', command=self.record,style='Fun.TButton',width=30)
        self.recordButton.grid(row=1,column=0,sticky='e'+'w',padx=10)
        
        self.stopButton = ttk.Button(self.pronunciationPlotFrame,text='Stop',command=self.stop,state='disabled',style='Fun.TButton',width=30)
        self.stopButton.grid(row=1,column=1,sticky='e'+'w',padx=10)

        self.analyseButton = ttk.Button(self.pronunciationPlotFrame,text='Analyse',command=self.analyse,state='disabled',style='Fun.TButton',width=30)
        self.analyseButton.grid(row=1,column=2,sticky='e'+'w',padx=10)

        self.scoreLabel = Label(self.pronunciationPlotFrame)
        

    def initialiseSounds(self):

        initializeSnack(self.root)
        self.recordedSound = Sound()

    def record(self):
        self.recordedSound.record()
        self.stopButton.config(state='normal')
        self.recordButton.config(state='disabled')
        

    def stop(self):
        self.recordedSound.stop()
        self.stopButton.config(state='disabled')
        self.recordButton.config(state='normal')
        self.analyseButton.config(state='normal')
        self.recordedSound.write(self.appDirectory+'\\htk\\test\\htktest.wav',start=0,end=-1)
	self.isRecording = False

    def analyse(self):
        if self.selectedWord == None:
            tkMessageBox.showerror('Error', 'No word selected')
        else:
            codettestFilePath = os.path.join(self.appDirectory,'htk\\user\\codettest.scp')
            codettestFile = open(codettestFilePath,'w')
            codettestFile.write(self.appDirectory + '\\htk\\test\\htktest.wav ' + self.appDirectory + '\\htk\\test\\htktest.mfc')
            codettestFile.close()

            testFilePath = os.path.join(self.appDirectory,'htk\\user\\test.scp')
            testFile = open(testFilePath,'w')
            testFile.write(self.appDirectory + '\\htk\\test\\htktest.mfc')
            testFile.close()

            labPath = os.path.join(self.appDirectory,'htk\\test\\htktest.lab')
            lab = open(labPath,'w')
            lab.write('silence\n' + self.selectedWord + '\nsilence')
            lab.close()

            #analyseBatchPath = os.path.join(self.appDirectory,'htk\\analyse.bat')
            self.performHtkCommands()

            scoreString = self.getScore()
            self.displayScore(scoreString)
            

    def performHtkCommands(self):
        hCopyCommand = self.appDirectory+'\\htk\\HCopy -T 1 -C ' + self.appDirectory + '\\htk\\user\\config0 -S ' + self.appDirectory + '\\htk\\user\\codettest.scp'
        hViteCommand = self.appDirectory+'\\htk\\HVite -a -o NW -m -C ' + self.appDirectory + '\\htk\\user\\config1 -H ' + self.appDirectory + '\\htk\\hmm40\\macros -H ' + self.appDirectory + '\\htk\\hmm40\\hmmdefs -S ' + self.appDirectory + '\\htk\\user\\test.scp -l * -i ' + self.appDirectory + '\\htk\\analysisresults.mlf -p 0.0 -s 5.0 -y lab -I ' + self.appDirectory + '\\htk\\user\\words.mlf ' + self.appDirectory + '\\htk\\user\\dict ' + self.appDirectory + '\\htk\\user\\monophones1'
        hResultsCommand = self.appDirectory+'\\htk\\HResults -I ' + self.appDirectory + '\\htk\\user\\words.mlf ' + self.appDirectory + '\\htk\\user\\monophones1 ' + self.appDirectory + '\\htk\\analysisresults.mlf > ' + self.appDirectory + '\\htk\\score.txt'
            
        os.system(hCopyCommand)
        os.system(hViteCommand)
        os.system(hResultsCommand)

    def getScore(self):
        scorePath = os.path.join(self.appDirectory,'htk\\score.txt')
        scoreFile = open(scorePath,'r')
        counter = 0
        score = None
        for line in scoreFile:
            if counter == 6:
                line = line.split(' ')
                score = line[1]
            counter+=1
        return score

    def displayScore(self,scoreString):
        score = scoreString[6:-1]
        colour = None
        font = ('Arial','20','bold')
        if score >= 90:
            colour = '#006600'
        else:
            colour = '#FF0000'
        self.scoreLabel.destroy()
        self.scoreLabel = Label(self.pronunciationPlotFrame,text='Correctness = ' + score,fg=colour,font=font)
        self.scoreLabel.config(text='Correctness = ' + score,fg=colour)
        self.scoreLabel.grid(row=2,column=1)

    def clearScore(self):
        font = ('Arial','20')
        self.scoreLabel.destroy()
        self.scoreLabel = Label(text='Correctness = ',font=font,fg='#000000')
        self.scoreLabel.grid(row=2,column=1)

    def updateWord(self,word):
        self.selectedWord = word
        self.updateWordLabel()
        self.analyseButton.config(state='disabled')

    def updateWordLabel(self):
        font = ('Arial','20')
        if self.selectedWord == None:
            word = 'No word has been selected'
            self.wordLabel = Label(self.pronunciationPlotFrame,text='No word has been selected',font=font)
            self.wordLabel.grid(row=0,column=0,sticky='n'+'e'+'s'+'w',columnspan=3)
        else:
            self.wordLabel = Label(self.pronunciationPlotFrame,text=self.selectedWord,font=font)
            self.wordLabel.grid(row=0,column=0,sticky='n'+'e'+'s'+'w',columnspan=3)
