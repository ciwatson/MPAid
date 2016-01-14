@Echo OFF
REM	****************************
REM	This batch file is used to generate a word list file by calling the Perl script named "prompts2wlist"
REM     Author: Sgaoqing Yu(Shawn)  15/01/2016
REM	****************************

Perl prompts2wlist Prompts.pmpt WordList.wlist

pause & exit