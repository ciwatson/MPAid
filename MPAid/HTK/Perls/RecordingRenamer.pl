#!/usr/bin/perl
use strict;
use File::Basename;
#use File::Copy qw(move);
use warnings;
use Encode;

die "Usage: $0 <input dir> <extion>\n" unless @ARGV == 2;
my $InputDir = $ARGV[0] ;
my $Ext = $ARGV[1] ;

my @WordList = (
            "teenei",    #01
            "taane",     #02
            "hau",      #03
            "hou",      #04
            "pao",      #05
            "pau",      #06
            "pou",      #07
            "poo",       #08
            "pai",      #09
            "pae",      #10
            "kee",       #11
            "kei",      #12
            "kii",       #13
            "hee",       #14
            "hei",      #15
            "hii",       #16
            "tae",      #17
            "tai",      #18
            "maatao",    #19
            "maatau",    #20
            "maatou",    #21
            "toetoe",   #22
            "toi",      #23
            "hoihoi",   #24
            "hoe",      #25
            "mao",      #26
            "mau",      #27
            "moutere",  #28
            "tuu",       #29
            "matiu"     #30
);

my %SpeakerHash = (
  "K004M" => "oldmale",
  "K005M" => "oldmale",
  "K006M" => "oldmale",
  "K007M" => "oldmale",
  "K008M" => "oldmale",
  "K009M" => "oldmale",
  "K010M" => "oldmale",

  "L1Y01M" => "youngmale",
  "L1Y02M" => "youngmale",
  "L1Y03M" => "youngmale",
  "L1Y04M" => "youngmale",
  "L1Y05M" => "youngmale",

  "L1H01M" => "youngfemale",
  "L1H02M" => "youngfemale",
  "L1H03M" => "youngfemale",
  "L1H04M" => "youngfemale",
  "L1H05M" => "youngfemale",
  "L1H06M" => "youngfemale",

  "R001M" => "oldfemale",
  "R002M" => "oldfemale",
  "R003M" => "oldfemale",
  "R004M" => "oldfemale",
  "R005M" => "oldfemale",
  "R006M" => "oldfemale",
  "R007M" => "oldfemale",
  "R008M" => "oldfemale"
);

opendir(DH, "$InputDir") or die "Can't open: $!\n" ;
#load all the files in $InputDir which have suffix "wav"
my @list = grep {/$Ext$/ && -f "$InputDir/$_" } readdir(DH) ;
closedir(DH) ;
chdir($InputDir) or die "Can't cd dir: $!\n" ;
foreach my $file (@list){
    my $Basename = basename($file,($Ext));

    my @parts=split(/_/,$Basename);
    if(@parts == 2){
        my $NewFile = $SpeakerHash{$parts[0]}."-word-".$WordList[$parts[1] - 1]."-".$parts[0].".".$Ext;
		
		#my @charsets = qw(utf-8 latin1 iso-8859-1 iso-8859-15 utf-16 gb2312 unicode ascii);
		#for (@charsets){print "$_: " . decode($_, $NewFile) . "\n";}
		
        if(-e $NewFile){
            warn "Duplicated name after renaming!";
            next;
        } else {
            rename($file, decode('utf-8', $NewFile));
            #move $file, $NewFile;
        }
    } else {
        warn "Invalid name format!";
        next;
    }
}