@Echo OFF
REM	****************************
REM	This batch file is used to generate the *.mlf and *.lab files by calling the Perl script named "prompts2mlf"
REM     Author: Sgaoqing Yu(Shawn)  15/01/2016
REM	****************************

Perl prompts2mlf mlf Prompts.pmpt

pause & exit