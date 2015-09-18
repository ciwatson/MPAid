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
from PIL import ImageTk
import ctypes
import time

import Image

import JpegImagePlugin    # import drivers for every image format you use
import PngImagePlugin
import GifImagePlugin
Image._initialized = 1


HEIGHT = 580
WIDTH = 1080
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
		
		
		self.loadVowelImages()

                self.soundCodes = {}
		self.maleSoundDict = {}
		self.femaleSoundDict ={}
		self.vowelList = []
		self.wordList = []
		vowelListPath = "data\maori\VowelCodes.csv"
		wordListPath = "data\maori\WordCodes.csv"
		
		self.initialiseSoundList(self.vowelList,vowelListPath)
		self.initialiseSoundList(self.wordList,wordListPath)
		self.initialiseSounds()
		self.initialiseKeyboardShortcuts()

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
        Displays a splash/loading screen.
        '''
        def initiateLoadingScreen(self):

                
		self.loadingScreen = Toplevel(self.root)
		self.positionWindowInCentre(self.loadingScreen,LOADINGSCREENWIDTH,LOADINGSCREENHEIGHT)
		self.loadingScreen.title(string='Loading Application...')

                loadingImage = Image.open(self.appDirectory + '\images\splash.png')
                loadingPhoto = ImageTk.PhotoImage(loadingImage)
		loadingLabel = Label(self.loadingScreen,image=loadingPhoto)
		loadingLabel.image = loadingPhoto
		loadingLabel.pack()
		self.root.update()
        
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
        Load images associated with the vowels into memory.
        '''
        def loadVowelImages(self):
                self.vowelImagesDict = {}
                greyImage = Image.open(self.appDirectory + '\\images\\grey.png')
                self.greyPhoto = ImageTk.PhotoImage(greyImage)               
                
                aImage = Image.open(self.appDirectory+'\\images\\a.jpg')
                aPhoto = ImageTk.PhotoImage(aImage)
                self.vowelImagesDict.update({'a':aPhoto})
                
                eImage = Image.open(self.appDirectory+'\\images\\e.jpg')
                ePhoto = ImageTk.PhotoImage(eImage)
                self.vowelImagesDict.update({'e':ePhoto})
                
                iImage = Image.open(self.appDirectory+'\\images\\i.jpg')
                iPhoto = ImageTk.PhotoImage(iImage)
                self.vowelImagesDict.update({'i':iPhoto})
                
                oImage = Image.open(self.appDirectory+'\\images\\o.jpg')
                oPhoto = ImageTk.PhotoImage(oImage)
                self.vowelImagesDict.update({'o':oPhoto})
                
                uImage = Image.open(self.appDirectory+'\\images\\u.jpg')
                uPhoto = ImageTk.PhotoImage(uImage)
                self.vowelImagesDict.update({'u':uPhoto})

                '''aeImage = Image.open(self.appDirectory+'\\images\\ae\\ae.gif')
                aePhoto = ImageTk.PhotoImage(aeImage)
                self.vowelImagesDict.update({'ae':uPhoto})'''
                self.loadDiphthongImages('ae')
                self.loadDiphthongImages('ai')
                self.loadDiphthongImages('ao')
                self.loadDiphthongImages('au')
                self.loadDiphthongImages('ou')

        def loadDiphthongImages(self,diphthong):
                fileList = glob.glob(self.appDirectory + '\\images\\' + diphthong + '\\*')
                self.vowelImagesDict.update({diphthong:[]})
                for imageFile in fileList:
                        newImage = Image.open(imageFile)
                        newPhoto = ImageTk.PhotoImage(newImage)
                        self.vowelImagesDict[diphthong].append(newPhoto)

         
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

		self.soundsFrame = Frame(self.root, width=SOUNDFRAMEWIDTH,height=SOUNDFRAMEHEIGHT,background='#EEEEEE')
		self.soundsFrame.grid(row=1,column=0)

                self.gender = BooleanVar()

                #For the radiobutton, True = male, False = female
                self.maleRadioButton = Radiobutton(self.soundsFrame,text='Male',variable=self.gender,value=True,command=self.updateGenderAffectedFunctions)
                self.maleRadioButton.grid(row=0,column=0,columnspan=2,sticky='w',padx=15)
                self.femaleRadioButton = Radiobutton(self.soundsFrame,text='Female',variable=self.gender,value=False,command=self.updateGenderAffectedFunctions)
                self.femaleRadioButton.grid(row=1,column=0,columnspan=2,sticky='w',padx=15)
                self.maleRadioButton.select()
                

		#End of sound widgets

                #Formant Plot widgets
		self.mainFrame = Frame(self.root, width=FORMANTPLOTFRAMEWIDTH, height=FORMANTPLOTFRAMEHEIGHT,background='#EEEEEE')
		self.mainFrame.grid(row=1,column=1)
		
		self.tabbedPane = Pmw.NoteBook(self.mainFrame)
		

		self.tabbedPane.pack(fill='both')
		self.formantTab = self.tabbedPane.add('Formant Plot')
		#self.pronunciationTab = self.tabbedPane.add('Pronunciation Aid')		

                self.formantPlot = FormantPlot(self.formantTab, self.appDirectory,self.root,self.getGender())
		
		#End of Formant Plot widgets

		#Pronunciation Plot widgets

		#self.pronunciationAid = PronunciationAid(self.pronunciationTab,self.appDirectory,self.root)

		#End Pronunciation Plot widgets
                self.tabbedPane.setnaturalsize()

                
		
		
		
		#self.frame = Frame(self.root)
		#self.frame.grid(row=1,column=0)
		
		'''
		self.aButton = Button(self.frame, text='a', command=(lambda:self.play(self.aSound)))
		self.aButton.grid(column=0,row=0)
		self.eButton = Button(self.frame, text='e', command=(lambda:self.play(self.eSound)))
		self.eButton.grid(column=0,row=1)
		self.iButton = Button(self.frame, text='i', command=(lambda:self.play(self.iSound)))
		self.iButton.grid(column=0,row=2)
		self.oButton = Button(self.frame, text='o', command=(lambda:self.play(self.oSound)))
		self.oButton.grid(column=0,row=3)
		self.uButton = Button(self.frame, text='u', command=(lambda:self.play(self.uSound)))
		self.uButton.grid(column=0,row=4)
		self.stopButton = Button(self.frame, text='Stop', command=self.stop)
		self.stopButton.grid(column=1,row=0)
		self.recButton = Button(self.frame, text='Record', command=self.record)
		self.recButton.grid(column=1,row=1)
		self.saveButton = Button(self.frame, text='Save', command=self.save)
		self.saveButton.grid(column=1,row=2)'''


	'''
        Load in the pathname (root-level) of where the application is stored in
        '''
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

                        '''for path in fileList:
                                path = os.path.basename(path)
                                #if path.find('_29') == -1:
                                        #continue
                                if path.find('R0') >= 0:
                                        continue
                                
                                outputPath = self.appDirectory+'\\htk\\train\\'
                                #temp.write(outputPath+path+' ')
                                path = path.replace('.wav','.mfc')
                                temp.write(outputPath+path+'\n')
                                
                                #temp=open(path,'w')
                                #temp.write('silence\n')
                                #temp.write('"*/' + path + '"\n')
                                key = key.replace('aa','ä')
                                key = key.replace('ee','ë')
                                key = key.replace('ii','ï')
                                key = key.replace('oo','ö')
                                key = key.replace('uu','ü')
                                #temp.write(key)
                                #temp.write('tü')
                                #temp.write('.\n\n')
                                #temp.write('\nsilence')
                                #temp.close()'''
                        
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
                                '''try:
                                        self.keepDiphthongImageLoop = True
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
                                        print ""'''
                                        
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

''' diphthongImageThread(Thread):
        def __init__(self):
                Thread.__init__(self)

        def run(self):'''
                
                
