import sys
import time
import struct
"""
vowelScorer maintains the scores from the vowel plot in order to send them
to the VowelPlotController.cs. Which creates the processs on which VowelPlot runs on.

vowelScorer Handles sending and recieving messages from the controller.
mainly the sending off the finally results to the analysis form.

Author: Joshua Brundan
"""
class VowelScorer:
    def __init__(self):
        self.isSafeToRecord = True
        self.plotRegions = ['Total','Centre', 'Second', 'Third', 'Not on Target']
        self.longVowels=['a:','e:','i:','o:','u:']

        #VowelRegionsCounts
        self.vowelPlotRegionsCounts = []
        for i in range(len(self.longVowels)):
            vowelPlotRegionCount = [0,0,0,0]
            self.vowelPlotRegionsCounts.append(vowelPlotRegionCount)

        self.totalPlotRegionsCounts = [0,0,0,0]

        #VowelPercentages
        self.vowelPlotCounts = [0,0,0,0,0]
        self.vowelScores = [0,0,0,0,0]
        self.vowelPlotPercentages = [100,100,100,100,100]


        #TotalPercentage
        self.totalPlotCount = 0
        self.totalScore = 0
        self.overallPercentage = 100


    """
    Called at the end of a round of the vowelPlot. Used to update all the data for the particular vowel.
    As well as the overall data.
    """
    def updateScore(self, vowel, rawScore, plottedInfo):

        index = self.getIndex(vowel, self.longVowels)

        #updateVowelPlotRegionsCount for vowel
        vowelPlotRegionCount = self.vowelPlotRegionsCounts[index]
        for i in range(4):
            vowelPlotRegionCount[i] += plottedInfo[i+1]
            self.totalPlotRegionsCounts[i] += plottedInfo[i+1]

        #update vowelPlotCounts and vowelScores
        self.vowelPlotCounts[index] += plottedInfo[0]
        self.vowelScores[index] += rawScore
        if self.vowelPlotCounts[index] == 0:
            percentage = 100
        else:
            percentage = (float)(self.vowelScores[index])/(float)(self.vowelPlotCounts[index])

        #update vowelPlotPercentages
        self.vowelPlotPercentages[index] = percentage

        #update totalPlotCount and totalScore
        self.totalPlotCount += plottedInfo[0]
        self.totalScore += rawScore

        #calculate overallPercentage
        self.overallPercentage = (float)(self.totalScore)/(float)(self.totalPlotCount)

    """
    Gets the index of a element in a list.
    """
    def getIndex(self, vowel, vowelList):
        for i in range(len(vowelList)):
            if vowel == vowelList[i]:
                return i
        print "Error Vowel not valid."
        return -1

    def createLineList(self):
        line1 = '{}'.format(self.totalPlotCount) + ' {:.1%}'.format(self.overallPercentage/100.0)
        region0 = self.totalPlotRegionsCounts[0]
        region1 = self.totalPlotRegionsCounts[1]
        region2 = self.totalPlotRegionsCounts[2]
        region3 = self.totalPlotRegionsCounts[3]
        line2 = "%d %d %d %d" % (region0, region1, region2, region3)

        #a:
        index = 0
        line3 = '{}'.format(self.vowelPlotCounts[index]) + ' {:.1%}'.format(self.overallPercentage/100.0)
        region0 = self.vowelPlotRegionsCounts[index][0]
        region1 = self.vowelPlotRegionsCounts[index][1]
        region2 = self.vowelPlotRegionsCounts[index][2]
        region3 = self.vowelPlotRegionsCounts[index][3]
        line4 = "%d %d %d %d" % (region0, region1, region2, region3)
        #e:
        index = 1
        line5 ='{}'.format(self.vowelPlotCounts[index]) + ' {:.1%}'.format(self.vowelPlotPercentages[index]/100.0)
        region0 = self.vowelPlotRegionsCounts[index][0]
        region1 = self.vowelPlotRegionsCounts[index][1]
        region2 = self.vowelPlotRegionsCounts[index][2]
        region3 = self.vowelPlotRegionsCounts[index][3]
        line6 = "%d %d %d %d" % (region0, region1, region2, region3)
        #i:
        index = 2
        line7 = '{}'.format(self.vowelPlotCounts[index]) + ' {:.1%}'.format(self.vowelPlotPercentages[index]/100.0)
        region0 = self.vowelPlotRegionsCounts[index][0]
        region1 = self.vowelPlotRegionsCounts[index][1]
        region2 = self.vowelPlotRegionsCounts[index][2]
        region3 = self.vowelPlotRegionsCounts[index][3]
        line8 = "%d %d %d %d" % (region0, region1, region2, region3)
        #o:
        index = 3
        line9 = '{}'.format(self.vowelPlotCounts[index]) + ' {:.1%}'.format(self.vowelPlotPercentages[index]/100.0)
        region0 = self.vowelPlotRegionsCounts[index][0]
        region1 = self.vowelPlotRegionsCounts[index][1]
        region2 = self.vowelPlotRegionsCounts[index][2]
        region3 = self.vowelPlotRegionsCounts[index][3]
        line10 = "%d %d %d %d" % (region0, region1, region2, region3)
        #u:
        index = 4
        line11 = '{}'.format(self.vowelPlotCounts[index]) + ' {:.1%}'.format(self.vowelPlotPercentages[index]/100.0)
        region0 = self.vowelPlotRegionsCounts[index][0]
        region1 = self.vowelPlotRegionsCounts[index][1]
        region2 = self.vowelPlotRegionsCounts[index][2]
        region3 = self.vowelPlotRegionsCounts[index][3]
        line12 = "%d %d %d %d" % (region0, region1, region2, region3)


        lineList = (line1+"\n")
        lineList = lineList + (line2+"\n")
        lineList = lineList + (line3+"\n")
        lineList = lineList + (line4+"\n")
        lineList = lineList + (line5+"\n")
        lineList = lineList + (line6+"\n")
        lineList = lineList + (line7+"\n")
        lineList = lineList + (line8+"\n")
        lineList = lineList + (line9+"\n")
        lineList = lineList + (line10+"\n")
        lineList = lineList + (line11+"\n")
        lineList = lineList + (line12+"\n")


        return lineList

    def safeToRecord(self):
        if(self.isSafeToRecord):
            return True
        else:
            return False

    def connectAndSendText(self):
        self.isSafeToRecord = False
        lineList = self.createLineList()

        f = open(r'\\.\pipe\NPSSVowelPlot', 'r+b', 0)
        i = 1

        f.write(struct.pack('I', len(lineList)) + lineList)   # Write str length and str
        f.seek(0)                               # EDIT: This is also necessary
        print 'Wrote:', lineList

        time.sleep(2)
        self.isSafeToRecord = True
