'''
A set of methods used by the formant aid to perform its task.
'''

from tkSnack import *
import SoundProcessing


PREEMPFACTOR = 0.95
FRAMELENGTHFORSINGLE = 0.005
FRAMELENGTHFORALL = 0.06
NUMFORMANTS = 3
LPCORDER = 12

'''
Retrieves the last formant of the currently recording sound.
Arguments: sound - sound file being processed.
           gender - boolean, True if male. False if female.
           getAll - boolean, True if the application requires all the formants of the audio file. False if it only wants the last one.
Errors - No sound is currently being recorded.
Returns - formant/s of recording sound.
'''
def getFormants(sound,gender,getAll):
    try:
        if gender == True:
            nomF1Freq = 400
        else:
            nomF1Freq = 500

        if getAll == True:
            formants = sound.formant(numformants=NUMFORMANTS,preemphasisfactor=PREEMPFACTOR,framelength=FRAMELENGTHFORALL,nom_f1_freq=nomF1Freq,lpcorder=LPCORDER)
        else:
            formants = sound.formant(numformants=NUMFORMANTS,preemphasisfactor=PREEMPFACTOR,framelength=FRAMELENGTHFORSINGLE,nom_f1_freq=nomF1Freq,lpcorder=LPCORDER)[len(sound.formant())-1]
        #soundCopy.destroy()
        #f1 = lastFormant[0]
        #f2 = lastFormant[1]
        #for f1,f2 in formants:
        #self.f1List.append(f1)
        #self.f2List.append(f2)
        #print soundCopy.formant()
        #print self.f1List
        #print "\n\n\n\n"
        return formants
    except IndexError:
        print "No formants found\n"
        return None

'''
Arguments: sound - sound file being processed.
           getAll - boolean, True if the application requires all the formants of the audio file. False if it only wants the last one.
Errors - No sound is currently being recorded.
Returns - 1.0 if the latest sound is from a person speaking. 0.0 if the latest sound is background noise.
'''
def getProbabilityOfVoicing(sound,getAll):
    try:
        if getAll == True:
            pitchValues = sound.pitch(method='ESPS',framelength=FRAMELENGTHFORALL)
            probabilityOfVoicing = []
            for pitchValue in pitchValues:
                probabilityOfVoicing.append(pitchValue[1])
            
            

        else:
            latestPitchValues = sound.pitch(method='ESPS',framelength=FRAMELENGTHFORSINGLE)[len(sound.pitch(method='ESPS')) - 1]
            probabilityOfVoicing = latestPitchValues[1]
            
            

        '''print "\n"
        print "PROBABILITY = "
        print probabilityOfVoicing
        print "LOUDNESS = "
        print loudness
        print "\n"'''
        return probabilityOfVoicing
    except IndexError:
        print "No sound available to get pitch yet"
        return 0.0

'''
Deletes the entire sound except for the last second of the sound
Returns - the last second of the sound
'''
def crop(sound):
    soundLength = sound.length(unit="SECONDS")
    soundInfo = sound.info()
    soundSampleRate = soundInfo[1]
    if soundLength > 1:
        sound.crop(start=(soundLength-1)*soundSampleRate,end=sound.length())
    return sound
