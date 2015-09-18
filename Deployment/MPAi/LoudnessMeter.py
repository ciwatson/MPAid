'''
Created on 29/11/2010

@author: Byron
'''

from Tkinter import *
from tkSnack import *


YOFFSET = 15

#The maximum root mean square (loudness) that the meter will record up to
MAXRMS = 16000
#The desired loudness when using the formant aid
RECOMMENDEDMAXLOUDNESS = 14000

'''
A meter that tracks how loud a particular live recording is. The loudness is measured in watts and the calculations are doen by dividing the watts with
the watts/pixel number.
'''
class LoudnessMeter():
    
    '''
    Initialises the height, width, and watts/pixel parameters needed for the loudness meter to function
    '''
    def __init__(self, canvas):

        self.canvas = canvas
        canvasWidth = self.getCanvasWidth()
        canvasHeight = self.getCanvasHeight()
        self.height = canvasHeight-(2*YOFFSET)
        self.wattsPerPixel = self.calculateWattsPerPixel()
        self.createMeter();
        

    '''
    Creates the outline of the meter
    '''
    def createMeter(self):
        
        self.canvas.create_rectangle((self.getCanvasWidth()/2)-20, YOFFSET, (self.getCanvasWidth()/2)+20, self.getCanvasHeight()-YOFFSET)

        recommendedMaxVolLevel = RECOMMENDEDMAXLOUDNESS/self.wattsPerPixel
        self.canvas.create_line((self.getCanvasWidth()/2)-20, self.getCanvasHeight()-YOFFSET-recommendedMaxVolLevel, (self.getCanvasWidth()/2)+20, self.getCanvasHeight()-YOFFSET-recommendedMaxVolLevel)

        #self.recommendedMaxVolLabel = Label(self.canvas, text="Maximum Volume Level")
        #self.recommendedMaxVolLabel.pack(padx=20)
        
        
    '''
    Returns the width of the canvas that the loudness meter is situated in
    '''
    def getCanvasWidth(self):
        canvasWidth = self.canvas.winfo_reqwidth()
        return canvasWidth

    '''
    Returns the height of the canvas that the loudness meter is situated in
    '''
    def getCanvasHeight(self):
        canvasHeight = self.canvas.winfo_reqheight()
        return canvasHeight

    '''
    Performs the calculations to get the loudness of the recording.
    Arguments: sound - the sound that is being recorded.
    Returns the loudness measured in watts.
    '''
    def calculateLoudness(self, sound):
        latestPitchValues = sound.pitch(method='ESPS')[len(sound.pitch(method='ESPS')) - 1]
        loudness = latestPitchValues[2]
        return loudness

    '''
    Returns watts/pixel number.
    '''
    def calculateWattsPerPixel(self):
        return MAXRMS/self.height

    '''
    Updates the loudness meter by drawing a new rectangle. The rectangles height being determined by the loudness level.
    Arguments: sound - the sound that is being recorded.
    '''
    def updateMeter(self, sound):
        self.canvas.delete("loudnessLevel")
        loudness = self.calculateLoudness(sound)
        loudnessLevelInPixels = loudness/self.wattsPerPixel
        self.canvas.create_rectangle((self.getCanvasWidth()/2)-20,self.getCanvasHeight()-YOFFSET-loudnessLevelInPixels,(self.getCanvasWidth()/2)+20,self.getCanvasHeight()-YOFFSET, fill='red', tags='loudnessLevel')

    '''
    Clears the meter
    '''
    def clearMeter(self):
        self.canvas.delete('loudnessLevel')
        
