from Tkinter import *
import tkFileDialog
from tkSnack import *
import os
from LoudnessMeter import *
import SoundProcessing
import thread
import Pmw
import ttk

'''
The formant plot takes a recorded sound (live input) and plots the recording onto the graph. It measures how 'open' the jaw is and how far 'back/forward'
the tongue is when the sound is being spoken and recorded. This information is plotted and compared to with a 'gold standard' (native Maori speaker).
'''

#Height and width of the frame which will contain the plot, loudness meter and buttons associated with the formant plot.
FORMANTPLOTFRAMEHEIGHT = 530
FORMANTPLOTFRAMEWIDTH = 950

#Height and width of the formant plot graph.
FORMANTPLOTHEIGHT = 460
FORMANTPLOTWIDTH = 850

#The number used to divide the f1 and f2 values of the formants being recorded from the user. This is used so that the recordings can fit on the plots dimensions.
SCALEDOWN = 3

#Used to help plot the formants in their correct positions.
XSHIFT = 55
YSHIFT = 55
XOFFSET = 100
YOFFSET = 50

class FormantPlot:

        '''
        Initialise the formant plot.
        Arguments: parent - the widget that the formant plot is contained in.
                   path - the directory path where the application is in.
                   root - the Tk widget which is the base of all the other widgets.
                   gender - user's gender
        '''
        def __init__(self, parent, path, root,gender):

                self.root = root
                self.parent = parent
                self.gender=gender
                self.appDirectory = path
                

                self.setUpWidgets()

                self.getGoldStandardMonophthongs(path)
                self.drawGoldStandardMonophthongs(gender)
                self.drawFormantPlotAxes()
                self.drawFormantPlotLegend()

                self.initialiseSounds()
                self.initialiseKeyboardShortcuts()

                self.isRecording=False
                self.previousF1 = 0
                self.previousF2 = 0

        '''
        Initialises all the widgets that are associated with the formant plot.
        '''
        def setUpWidgets(self):

                self.formantPlotFrame = Frame(self.parent, width=FORMANTPLOTFRAMEWIDTH, height=FORMANTPLOTFRAMEHEIGHT)
                self.formantPlotFrame.grid()
                
		self.formantPlotCanvas = SnackCanvas(self.formantPlotFrame, height=FORMANTPLOTHEIGHT, width=FORMANTPLOTWIDTH, bg='white')
		self.formantPlotCanvas.grid(row=0,column=0)

		self.loudnessMeterCanvas = SnackCanvas(self.formantPlotFrame, height=FORMANTPLOTHEIGHT, width=FORMANTPLOTFRAMEWIDTH-FORMANTPLOTWIDTH, bg='white')
		self.loudnessMeterCanvas.grid(row=0,column=1)

		self.formantPlotControlFrame = Frame(self.formantPlotFrame)
		self.formantPlotControlFrame.grid(row=1,column=0,sticky='w'+'e',columnspan=2)

		self.formantPlotControlFrame.columnconfigure(0, minsize=FORMANTPLOTWIDTH/3)
		self.formantPlotControlFrame.columnconfigure(1, minsize=FORMANTPLOTWIDTH/3)
		self.formantPlotControlFrame.columnconfigure(2, minsize=FORMANTPLOTWIDTH/3)
		self.formantPlotControlFrame.columnconfigure(3, minsize=FORMANTPLOTFRAMEWIDTH-FORMANTPLOTWIDTH)

                self.isLabelsOn = BooleanVar()
                self.toggleLabelCheckbox = Checkbutton(self.formantPlotControlFrame,text='Show Labels',variable=self.isLabelsOn,onvalue=True,offvalue=False,state='active',command=(lambda:self.togglePlot(self.isLabelsOn.get(),'ellipseLabel')))
                self.toggleLabelCheckbox.grid(row=0,column=0)
                self.toggleLabelCheckbox.select()

                self.isEllipsesOn = BooleanVar()
                self.toggleEllipsesCheckbox = Checkbutton(self.formantPlotControlFrame,text='Show Ellipses',variable=self.isEllipsesOn,onvalue=True,offvalue=False,state='active',command=(lambda:self.togglePlot(self.isEllipsesOn.get(),'ellipses')))
                self.toggleEllipsesCheckbox.grid(row=0,column=1)
                self.toggleEllipsesCheckbox.select()

                self.isLoadedFormantsOn = BooleanVar()
                self.toggleLoadedFormantsCheckbox = Checkbutton(self.formantPlotControlFrame,text='Show Loaded Formants',variable=self.isLoadedFormantsOn,onvalue=True,offvalue=False,state='active',command=(lambda:self.togglePlot(self.isLoadedFormantsOn.get(),'loadedformants')))
                self.toggleLoadedFormantsCheckbox.grid(row=0,column=2)
                self.toggleLoadedFormantsCheckbox.select()

                self.recButton = ttk.Button(self.formantPlotControlFrame, text='Record', command=self.record,style='Fun.TButton')
		self.recButton.grid(row=1,column=0,sticky='w'+'e',padx=10)
		self.stopButton = ttk.Button(self.formantPlotControlFrame, text='Stop', command=self.stop,state='disabled',style='Fun.TButton')
		self.stopButton.grid(row=1,column=1,sticky='w'+'e',padx=10)
		self.playRecordButton = ttk.Button(self.formantPlotControlFrame, text='Play Last Recorded Sound', command=(lambda:(self.play(self.recordedAudio))),state='disabled',style='Fun.TButton')
		self.playRecordButton.grid(row=1,column=2,sticky='w'+'e',padx=10)
		

		self.loadAudioButton = ttk.Button(self.formantPlotControlFrame, text='Load Audio File', command=self.loadAudioFile,state='normal',style='Fun.TButton')
		self.loadAudioButton.grid(row=2,column=1,sticky='w'+'e',padx=10)
		self.saveButton = ttk.Button(self.formantPlotControlFrame, text='Save', command=self.save,state='disabled',style='Fun.TButton')
		self.saveButton.grid(row=2,column=0,sticky='w'+'e',padx=10)
		self.playLoadButton = ttk.Button(self.formantPlotControlFrame, text='Play Loaded File', command=(lambda:(self.play(self.loadedAudio))),state='disabled',style='Fun.TButton')
		self.playLoadButton.grid(row=2,column=2,sticky='w'+'e',padx=10)

		self.clearScreenButton = ttk.Button(self.formantPlotControlFrame, text='Clear Plot', command=self.clearUserFormants,state='normal',style='Fun.TButton')
		self.clearScreenButton.grid(row=1,column=3,sticky='w'+'e'+'n'+'s', rowspan=2)

		self.loudnessMeter = LoudnessMeter(self.loudnessMeterCanvas)

	'''
        Creates the Snack Sound objects used in the formant plot.
        '''
	def initialiseSounds(self):
		initializeSnack(self.root)
		self.recordedAudio = Sound()
		self.soundCopy = Sound()
		self.loadedAudio = Sound()


	def initialiseKeyboardShortcuts(self):
                self.root.bind('<space>',self.executeSpacebarInput)
                
	'''
        Draw the axes for the formant plot.
        '''
	def drawFormantPlotAxes(self):
                #X axis
		self.formantPlotCanvas.create_line(XSHIFT,FORMANTPLOTHEIGHT-YSHIFT,FORMANTPLOTWIDTH,FORMANTPLOTHEIGHT-YSHIFT, tags="formantAxes")
		#Y axis
		self.formantPlotCanvas.create_line(XSHIFT,0,XSHIFT,FORMANTPLOTHEIGHT-YSHIFT, tags="formantAxes")

		#X axis label
		self.formantPlotCanvas.create_text((XSHIFT+FORMANTPLOTWIDTH)/2, FORMANTPLOTHEIGHT-YSHIFT+30,text = "Tongue Position", tags="formantAxes")
		self.formantPlotCanvas.create_text(XSHIFT+12, FORMANTPLOTHEIGHT-YSHIFT+10,text = "Front", tags="formantAxes")
		self.formantPlotCanvas.create_text(FORMANTPLOTWIDTH-15, FORMANTPLOTHEIGHT-YSHIFT+10,text = "Back", tags="formantAxes")

		#Y axis label
		self.formantPlotCanvas.create_text(XSHIFT/2, (FORMANTPLOTHEIGHT-YSHIFT)/2,text = "Mouth", tags="formantAxes")
		self.formantPlotCanvas.create_text(XSHIFT/2, ((FORMANTPLOTHEIGHT-YSHIFT)/2)+20,text = "Openness", tags="formantAxes")
		self.formantPlotCanvas.create_text(XSHIFT/2, FORMANTPLOTHEIGHT-YSHIFT-10,text = "Open", tags="formantAxes")
                self.formantPlotCanvas.create_text(XSHIFT/2, 10,text = "Closed", tags="formantAxes")
                                                   

        def drawFormantPlotLegend(self):
                self.formantPlotCanvas.create_oval(FORMANTPLOTWIDTH-120-3,10-3,FORMANTPLOTWIDTH-120+3,10+3,tag='legend',fill='black')
                self.formantPlotCanvas.create_text(FORMANTPLOTWIDTH-60,10,text='Recorded Formants',tag='legend')
                self.formantPlotCanvas.create_oval(FORMANTPLOTWIDTH-120-3,30-3,FORMANTPLOTWIDTH-120+3,30+3,tag='legend',fill='red')
                self.formantPlotCanvas.create_text(FORMANTPLOTWIDTH-64,30,text='Loaded Formants',tag='legend')
                                                   
        '''
	Loads the monophthong data.
	Arguments: path - directory path of where the application is stored in.
	'''
	def getGoldStandardMonophthongs(self, path):
		#Initialise the male data
		self.maleMonophthongData = []
		maleMonophthongDataPath = os.path.join(path, 'data\maori\monDataMale.txt')
		maleMonophthongFile = open(maleMonophthongDataPath,'r')
		
		#Initialise the female data
		self.femaleMonophthongData = []
		femaleMonophthongDataPath = os.path.join(path, 'data\maori\monDataFemale.txt')
		femaleMonophthongFile = open(femaleMonophthongDataPath,'r')
		
		#Code from ywan478 2010 SoftEng206 Project
		#Load in the monophthong data for males
		for monophthongDataLine in maleMonophthongFile:
			monophthongDataLine = monophthongDataLine.split()
			
			#F1 mean and standard deviation
			monophthongDataLine[0]= (int(float(monophthongDataLine[0]))/SCALEDOWN)
			monophthongDataLine[1]= (int(float(monophthongDataLine[1]))/SCALEDOWN)
			
			#F2 mean and standard deviation
			monophthongDataLine[2]= FORMANTPLOTWIDTH - (int(float(monophthongDataLine[2]))/SCALEDOWN) + XSHIFT + XOFFSET
			monophthongDataLine[3]= (int(float(monophthongDataLine[3]))/SCALEDOWN)

			self.maleMonophthongData.append(monophthongDataLine)
			
		#Load in the monophthong data for females
		for monophthongDataLine in femaleMonophthongFile:
			monophthongDataLine = monophthongDataLine.split()
			
			#F1 mean and standard deviation
			monophthongDataLine[0]= (int(float(monophthongDataLine[0]))/SCALEDOWN)
			monophthongDataLine[1]= (int(float(monophthongDataLine[1]))/SCALEDOWN)
			
			#F2 mean and standard deviation
			monophthongDataLine[2]= FORMANTPLOTWIDTH - (int(float(monophthongDataLine[2]))/SCALEDOWN) + XSHIFT + XOFFSET
			monophthongDataLine[3]= (int(float(monophthongDataLine[3]))/SCALEDOWN)
		
			self.femaleMonophthongData.append(monophthongDataLine)
                			
			#End code from ywan478

        '''
        Draw the gold standard monophthong data into the formant plot.
	Arguments: gender - gender of the user. True if male. False if female.
	'''
        def drawGoldStandardMonophthongs(self, gender):

                if gender==True:
                        data = self.maleMonophthongData
                else:
                        data = self.femaleMonophthongData
                #Code from ywan478 2010 SoftEng206 Project
                for f1mean, f1sd, f2mean, f2sd, vowel in data:
                        font = ('Arial','10','bold')
			self.formantPlotCanvas.create_oval(f2mean-f2sd,f1mean-f1sd,f2mean+f2sd,f1mean+f1sd, outline='black', tag='ellipses')
			self.formantPlotCanvas.create_text(f2mean,f1mean,fill='red',font=font,tag='ellipseLabel', text=vowel)
			
		#End code from ywan478

	'''
        Plots the last formant of the recording sound into the formant plot.
        Arguments: sound - the sound that is being recorded.
        '''
	def plotFormants(self, sound):
		

		probabilityOfVoicing = SoundProcessing.getProbabilityOfVoicing(sound,False)

                if probabilityOfVoicing == 1.0:
                        
                        formants = SoundProcessing.getFormants(sound,self.gender,False)

                
                        #Only plot the latest formants of the sound if there's a good chance that it is the user speaking instead of background noise.
                        if formants != None:
                                #self.f1List.append(formants[0])
                                #self.f2List.append(formants[1])
                        
                                latestF1 = formants[0]/SCALEDOWN
                                latestF2 = FORMANTPLOTWIDTH - (formants[1]/SCALEDOWN) + XSHIFT + XOFFSET
                                #if abs(self.previousF1-latestF1) < 150 and abs(self.previousF2-latestF2) < 150:
                                #print latestF1
                                #print latestF2
                                #print "\n\n"
                                if latestF2 > XSHIFT and latestF1 < FORMANTPLOTHEIGHT-YSHIFT:
                                        self.formantPlotCanvas.create_oval(latestF2-2,latestF1-2,latestF2+2,latestF1+2, fill='black', tags="userformants")

                                #self.previousF1 = latestF1
                                #self.previousF2 = latestF2
                
                        if not self.isRecording:
                                if formants != None:
                                        #print self.soundCopy.formant()
                                        #print self.f1List
                                        #print self.f2List
                                        print ""

        '''
        Update the loudness level in the loudness meter.
        Arguments: sound - the sound that is currently being recorded.
        '''
        def updateLoudnessMeter(self, sound):
                try:
                        self.loudnessMeter.updateMeter(sound)
                        
                except IndexError:
                        print "No sound available to get loudness yet"


        '''
        Update the formant plot and loudness meter if the user is still recording.
        '''
        def updateAllCanvases(self):
                self.soundCopy.copy(self.recordedAudio)
                SoundProcessing.crop(self.soundCopy)
                self.plotFormants(self.soundCopy)
                self.updateLoudnessMeter(self.soundCopy)
                if self.isRecording:
                        self.root.after(30,self.updateAllCanvases)

        '''
        Clears the user's formant data from the formant plot.
        '''
        def clearUserFormants(self):
                self.formantPlotCanvas.delete('userformants')

        '''
        Clears the gold standard data from the formant plot.
        '''
        def clearGoldStandard(self):
                self.formantPlotCanvas.delete('ellipseLabel')
                self.formantPlotCanvas.delete('ellipses')

        '''
        Redraws the gold standard data on the formant plot if the user's gender is changed.
        Arguments: gender - user's gender.
        '''
        def updateGoldStandard(self, gender):
                self.clearGoldStandard()
                self.drawGoldStandardMonophthongs(gender)

        def updateGender(self,gender):
                self.gender = gender

        def play(self,sound):
                sound.play(blocking=True)
                
                
                
        '''
        Stops the recording.
        '''
	def stop(self):
                
		self.recordedAudio.stop()
		self.recButton.config(state='normal')
		self.saveButton.config(state='normal')
		self.playRecordButton.config(state='normal')
		self.stopButton.config(state='disabled')
		self.isRecording = False
		self.root.after(200,self.loudnessMeter.clearMeter)

	'''
	Start recording the user's sounds and make the formant plot react accordingly.
	'''
 	def record(self): #Record sound file
                self.clearUserFormants();
		self.recordedAudio.record()
		self.isRecording = True
		self.recButton.config(state='disabled')
		self.stopButton.config(state='normal')

		self.root.after(200,self.updateAllCanvases)
		
        '''
        Saves the latest recording from the user.
        '''
	def save(self):
		saveName = tkFileDialog.asksaveasfilename(defaultextension=".wav")
		self.recordedAudio.write(saveName,start=0,end=-1)

	def loadAudioFile(self):
                filename = tkFileDialog.askopenfilename(initialdir=self.appDirectory)
                
                self.formantPlotCanvas.delete('loadedformants')
                
                self.loadedAudio.config(load=filename)
                self.playLoadButton.config(state='normal')
                loadedFormants = SoundProcessing.getFormants(self.loadedAudio,self.gender,True)
                probabilityOfVoicingList = SoundProcessing.getProbabilityOfVoicing(self.loadedAudio,True)
                self.formantPlotCanvas.delete('loadedformants')
                #print len(loadedFormants)
                #print len(probabilityOfVoicingList)
                try:
                    for i in range(0,len(loadedFormants)):
                        probabilityOfVoicing = probabilityOfVoicingList[i]
                        if probabilityOfVoicing == 1.0:
                            formant = loadedFormants[i]
                            f1 = formant[0]/SCALEDOWN
                            f2 = FORMANTPLOTWIDTH - (formant[1]/SCALEDOWN) + XSHIFT + XOFFSET
                            self.formantPlotCanvas.create_oval(f2-2,f1-2,f2+2,f1+2, fill='red', tags="loadedformants")
                except IndexError:
                    print ""
                        

        '''
        Displays/hides a specified aspect of the formant plot presentation.
	Arguments: boolean - true/false indicates whether the plot should display/hide the specified thing.
		    tag - the thing that is going to be displayed/hidden.
	'''
        def togglePlot(self,boolean,tag):
                if boolean:
                        self.formantPlotCanvas.itemconfig(tag, state='normal')
                else:
                       self.formantPlotCanvas.itemconfig(tag, state='hidden')

        def executeSpacebarInput(self,event):
                if self.isRecording == False:
                        self.record()
                else:
                        self.stop()
