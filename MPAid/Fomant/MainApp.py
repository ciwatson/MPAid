# -*- coding: cp1252 -*-
"""

2010 Summer Scholarship Project.

Author:  Byron Hui
UPI: bhui004
ID: 4974689

"""




from Tkinter import *
import ttk
import tkMessageBox
import tkFileDialog
from tkSnack import *
import os
from LoudnessMeter import *
from FormantPlot import *
import SoundProcessing
from PronunciationAid import *
import thread
from threading import Thread
import Pmw
import glob
import csv
import random
import ImageTk
import ctypes
import time


import Image

import JpegImagePlugin    # import drivers for every image format you use
import PngImagePlugin
import GifImagePlugin
from Tix import COLUMN
Image._initialized = 1


HEIGHT = 557
WIDTH = 970
FORMANTPLOTFRAMEHEIGHT = 530
FORMANTPLOTFRAMEWIDTH = 950

SOUNDFRAMEWIDTH = 200
SOUNDFRAMEHEIGHT = 480

LOADINGSCREENHEIGHT = 250
LOADINGSCREENWIDTH = 450


class MainApp:
	def __init__(self):
		self.initialiseRoot()
		self.getApplicationPathname()

		#Hide the main application window
		self.root.withdraw()

        #self.initiateLoadingScreen()
		
		
		#self.loadVowelImages()

                self.soundCodes = {}
		self.maleSoundDict = {}
		self.femaleSoundDict ={}
		self.vowelList = []
		self.wordList = []
		#vowelListPath = "data\maori\VowelCodes.csv"
		#wordListPath = "data\maori\WordCodes.csv"
		
		#self.initialiseSoundList(self.vowelList,vowelListPath)
		#self.initialiseSoundList(self.wordList,wordListPath)
		#self.initialiseSounds()
		#self.initialiseKeyboardShortcuts()

		self.setUpWidgets()

		#Bring the main application window back into display
		self.root.deiconify()
		#Delete the loading screen window as the application has finished loading
                #self.loadingScreen.destroy()
		
		

		
		self.f1List = []
		self.f2List = []

		'''
		tempPath = os.path.join(self.appDirectory,'data\maori\WordCodes.csv')
		reader = csv.reader(open(tempPath, "rb"))
                for row in reader:
                        print row'''


        def positionWindowInCentre(self,widget,widgetWidth,widgetHeight):
                user32 = ctypes.windll.user32
                screenXCentre = user32.GetSystemMetrics(0)
                screenYCentre = user32.GetSystemMetrics(1)
                geometryString = str(widgetWidth)+'x'+str(widgetHeight)+'+'+str((screenXCentre/2)-(widgetWidth/2))+'+'+str((screenYCentre/2)-(widgetHeight/4)-(widgetHeight/4))
                widget.geometry(geometryString)
        
        
	'''	
	Creates the Tk object needed that stores all the widgets
	'''
	def initialiseRoot(self):
		self.root = Tk()
		self.root.title("Formant Plot")
		self.root.protocol("WM_DELETE_WINDOW", self.quit) 
		self.root.resizable(True,True) #Disables window resizing
		self.positionWindowInCentre(self.root,WIDTH,HEIGHT)
	'''
        Initialise the user interface of the application
        '''
	def setUpWidgets(self):
                #Top widgets
                #self.headerFrame = Frame(self.root, width=WIDTH)
                #self.headerFrame.grid(row=0,column=0,columnspan=2)
                #headerImage = Image.open(self.appDirectory + '\\images\\header.png')
                #headerPhoto = ImageTk.PhotoImage(headerImage)
                #self.headerLabel = Label(self.headerFrame,image=headerPhoto,width=WIDTH,height=65,bg='orange')
                #self.headerLabel.image = headerPhoto
                #self.headerLabel.pack()
                #End top widgets

                #Sound widgets
		Pmw.initialise(self.root)
                #Pmw.Color.setscheme(self.root,background='#EEEEEE')

		#self.soundsFrame = Frame(self.root, width=SOUNDFRAMEWIDTH,height=SOUNDFRAMEHEIGHT,background='#EEEEEE')
		#self.soundsFrame.grid(row=1,column=0)
                

		#End of sound widgets

                #Formant Plot widgets
		self.mainFrame = Frame(self.root, width=FORMANTPLOTFRAMEWIDTH, height=FORMANTPLOTFRAMEHEIGHT,background='#EEEEEE')
		self.mainFrame.grid(row=1,column=1)


		self.tabbedPane = Pmw.NoteBook(self.mainFrame)


		self.tabbedPane.pack(fill='both')
		#self.formantTab = self.tabbedPane.add('Formant Plot')
		self.formantTab = self.tabbedPane.add('Senior Male')
		self.formantTab1 = self.tabbedPane.add('Young Male')
		self.formantTab2 = self.tabbedPane.add('Senior Female')
		self.formantTab3 = self.tabbedPane.add('Young Female')

		
		self.formantPlot = FormantPlot(self.formantTab, self.appDirectory,self.root,True,0)
		self.formantPlot1 = FormantPlot(self.formantTab1, self.appDirectory,self.root,True,1)
		self.formantPlot2 = FormantPlot(self.formantTab2, self.appDirectory,self.root,False,2)
		self.formantPlot3 = FormantPlot(self.formantTab3, self.appDirectory,self.root,False,3)
		

		
		self.menubar = Menu(self.root)
		self.filemenu1 = Menu(self.menubar)
		self.filemenu2 = Menu(self.menubar)
		self.filemenu3 = Menu(self.menubar,tearoff=0)
		
		self.menubar.add_cascade(label="File", font = "Arial 13",menu=self.filemenu1)
		self.filemenu1.add_command(label="Save",font = ('Arial','13'),command=(lambda:self.save()))
		self.filemenu1.add_command(label="Load Audio File",font = ('Arial','13'),command=(lambda:self.load()))
		self.filemenu1.add_command(label="Play Last Recorded Sound",font = ('Arial','13'),state='disabled')
		self.filemenu1.add_command(label="Play Loaded File",font = ('Arial','13'),state='disabled')
		self.menubar.add_cascade(label="Show",font = ('Arial','13'), menu=self.filemenu2)
		self.filemenu2.add_command(label="Show Loaded Vowels",font = ('Arial','13'),command=(lambda:self.showVowel()))
		self.filemenu2.add_command(label="Hide Loaded Vowels",font = ('Arial','13'),command=(lambda:self.hideVowel()))
		
		self.root.config(menu=self.menubar) 
		
		
		

		#self.pronunciationTab = self.tabbedPane.add('Pronunciation Aid')		

		
		#End of Formant Plot widgets

		#Pronunciation Plot widgets

		#self.pronunciationAid = PronunciationAid(self.pronunciationTab,self.appDirectory,self.root)

		#End Pronunciation Plot widgets
                self.tabbedPane.setnaturalsize()

                
		
		
		
		#self.frame = Frame(self.root)
		#self.frame.grid(row=1,column=0)
		


	'''
        Load in the pathname (root-level) of where the application is stored in
        
        '''
	def load(self):
		page = self.tabbedPane.getcurselection()
		if page == 'Senior Male':
			self.formantPlot.loadAudioFile()
		elif page == 'Young Male':
			self.formantPlot1.loadAudioFile()
		elif page == 'Senior Female':
			self.formantPlot2.loadAudioFile()
		elif page == 'Young Female':
			self.formantPlot3.loadAudioFile()
		
		self.filemenu1.entryconfig(3,state='normal')
		self.filemenu1.entryconfig(4,state='normal')


		
	def save(self):
		page = self.tabbedPane.getcurselection()
		if page == 'Senior Male':
			self.formantPlot.save()
		elif page == 'Young Male':
			self.formantPlot1.save()
		elif page == 'Senior Female':
			self.formantPlot2.save()
		elif page == 'Young Female':
			self.formantPlot3.save()
			
			
	def playLoad(self):
		page = self.tabbedPane.getcurselection()
		if page == 'Senior Male':
			self.formantPlot.play(self.formantPlot.loadedAudio)
		elif page == 'Young Male':
			self.formantPlot1.play(self.formantPlot1.loadedAudio)
		elif page == 'Senior Female':
			self.formantPlot2.play(self.formantPlot2.loadedAudio)
		elif page == 'Young Female':
			self.formantPlot3.play(self.formantPlot3.loadedAudio)

	def showVowel(self):
		page = self.tabbedPane.getcurselection()
		if page == 'Senior Male':
			self.formantPlot.formantPlotCanvas.itemconfig('loadedformants', state='normal')
		elif page == 'Young Male':
			self.formantPlot1.formantPlotCanvas.itemconfig('loadedformants', state='normal')
		elif page == 'Senior Female':
			self.formantPlot2.formantPlotCanvas.itemconfig('loadedformants', state='normal')
		elif page == 'Young Female':
			self.formantPlot3.formantPlotCanvas.itemconfig('loadedformants', state='normal')
			
	def hideVowel(self):
		page = self.tabbedPane.getcurselection()
		if page == 'Senior Male':
			self.formantPlot.formantPlotCanvas.itemconfig('loadedformants', state='hidden')
		elif page == 'Young Male':
			self.formantPlot1.formantPlotCanvas.itemconfig('loadedformants', state='hidden')
		elif page == 'Senior Female':
			self.formantPlot2.formantPlotCanvas.itemconfig('loadedformants', state='hidden')
		elif page == 'Young Female':
			self.formantPlot3.formantPlotCanvas.itemconfig('loadedformants', state='hidden')
    	
		
		
		
	def getApplicationPathname(self):
		filePath = os.getcwd()
		self.appDirectory = os.path.dirname(filePath)
		print self.appDirectory
		print os.path.dirname(sys.path[0])

        '''
        Load in a list of sound names.
        '''
	def initialiseSoundList(self, soundList, path):
                listPath = os.path.join(self.appDirectory,path)
                listFile = open(listPath,'r')
                for line in listFile:
                        line=line.split(",")
                        line[0] = line[0].replace('aa','ä')
                        line[0] = line[0].replace('ee','ë')
                        line[0] = line[0].replace('ii','ï')
                        line[0] = line[0].replace('oo','ö')
                        line[0] = line[0].replace('uu','ü')
                        soundList.append(line[0])
                        self.soundCodes.update({line[0]:line[1]})
                        

        
        
        '''
        Populate listbox with sounds
        '''
        def insertSoundNamesIntoListbox(self, soundList, listbox):
                for soundName in sorted(set(soundList)):
                        listbox.insert(END, soundName)
                
        
        def initialiseSounds(self):
                initializeSnack(self.root)
                extension = '.wav'
                #tempDir = os.path.join(self.appDirectory,'htk\\user\\train.scp')
                #temp=open(tempDir,'w')
                #temp.write('#!MLF!#\n')
                
                for key,code in self.soundCodes.items():
                        if self.isInt(code) == True:
                                if code >= 10:
                                        filePathEnd = '*_' + code + extension
                                else:
                                        filePathEnd = '*_0' + code + extension

                        else:
                                filePathEnd = code + extension


                        fileList = glob.glob(self.appDirectory+ '\\sounds\\' + filePathEnd)

                        
                        self.maleSoundDict.update({key:[]})
                        self.femaleSoundDict.update({key:[]})
                        for filePath in fileList:
                                
                                soundFileCode = os.path.basename(filePath)
                                #self.maleSoundDict[key].append(Sound(load=(filePath)))
                                if soundFileCode.startswith('L') == True or soundFileCode.startswith('K') == True:
                                        self.maleSoundDict[key].append(Sound(load=(filePath)))
                                elif soundFileCode.startswith('R') == True:
                                        self.femaleSoundDict[key].append(Sound(load=(filePath)))
                                else:
                                        self.maleSoundDict[key].append(Sound(load=(filePath)))
                                        self.femaleSoundDict[key].append(Sound(load=(filePath)))
                        
                #temp.close()

        def initialiseKeyboardShortcuts(self):
                self.root.bind('<Return>',self.executeEnterInput)

        def getLoopPlayNum(self):
                return self.loopPlayTextbox.get()

        def getActiveTabName(self, widget):
                return widget.getcurselection()


        def isInt(self,value):
                try:
                        int(value)
                        return True
                except:
                        return False

        def getGender(self):
                return self.gender.get()

        def updateGenderAffectedFunctions(self):
                self.formantPlot.updateGoldStandard(self.getGender())
                self.formantPlot.updateGender(self.getGender())

        def sendUpdates(self,event):
                self.updateVowelImage()
                if self.getActiveTabName(self.soundsTabbedPane) == 'Words':
                        word = self.getCurrentSelection()
                        self.pronunciationAid.updateWord(word)
                else:
                        self.pronunciationAid.updateWord(None)
                self.pronunciationAid.clearScore()
                
        def updateVowelImage(self):
                self.loopPlay = False
                self.keepDiphthongImageLoop = False
                vowel = self.getCurrentSelection()
                if self.vowelImagesDict.has_key(vowel) == True:
                        if len(vowel) == 1:
                                newPhoto = self.vowelImagesDict[vowel]
                                self.vowelsImageSection.config(image=newPhoto)
                                self.vowelsImageSection.image=newPhoto
                                self.isDiphthong = False
                        else:
                                newPhoto = self.vowelImagesDict[vowel][0]
                                self.vowelsImageSection.config(image=newPhoto)
                                self.vowelsImageSection.image=newPhoto
                                self.isDiphthong = True
                                        
                else:
                        self.vowelsImageSection.config(image=self.greyPhoto)
                        self.vowelsImageSection.image=self.greyPhoto
                        self.isDiphthong = False
                
                
        
	def getCurrentSelection(self):
                listbox = self.getActiveListbox(self.getActiveTabName(self.soundsTabbedPane))
                soundNameIndex = listbox.curselection()
                soundName = listbox.get(soundNameIndex)
                return soundName

        def loopThroughDiphthongImage(self):
                try:
                        self.keepDiphthongImageLoop = True
                        vowel = self.getCurrentSelection()
                        for i in range(0,len(self.vowelImagesDict[vowel])-1):
                                if self.keepDiphthongImageLoop == True:
                                        newPhoto = self.vowelImagesDict[vowel][i]
                                        self.vowelsImageSection.config(image=newPhoto)
                                        self.vowelsImageSection.image=newPhoto
                                        self.soundsFrame.update()
                                        time.sleep(0.05)
                                else:
                                        break
                except:
                        print ""
                
	
	def play(self):
                self.loopPlay = True
                gender = self.getGender()
                if gender == True:
                        soundDict = self.maleSoundDict
                else:
                        soundDict = self.femaleSoundDict

                #print len(soundDict['kii'])
                #print len(self.maleSoundDict['kii'])
                try:
                        soundName = self.getCurrentSelection()
                        #print soundName
                        for i in range(0,int(self.getLoopPlayNum())):
                                if self.loopPlay == True:
                                        numVersionsOfSound = len(soundDict[soundName])
                                        #print numVersionsOfSound
                                        randomNum = random.randint(0,numVersionsOfSound-1)
                                        #print randomNum
                                        sound = soundDict[soundName][randomNum]
                                        sound.play(blocking=True)
                                        if self.isDiphthong == True:
                                                self.loopThroughDiphthongImage()
                                        time.sleep(0.5)
                                else:
                                        break
                except TclError:
                        tkMessageBox.showerror('Error', 'No audio file selected')

                
		
	def quit(self):
		self.root.destroy()

	def executeEnterInput(self,event):
                self.play()

 
		
		
	def mainloop(self):

		self.root.mainloop()

                
                
