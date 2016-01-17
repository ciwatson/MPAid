#!/usr/bin/perl
use strict;
use Cwd;
use File::Basename;
use warnings;
use open ':encoding(iso-8859-1)';
use open IO => ':encoding(utf-8)';

die "Usage: $0 <dir> <extion>\n" unless @ARGV == 2;
my $Dir = $ARGV[0] ;
my $Ext = $ARGV[1] ;
opendir(DH, "$Dir") or die "Can't open: $!\n" ;

my $CWD = getcwd;
open STDOUT, ">Script.scp" or die "can't open file Script.scp:$!";

#读取指定文件夹下面的指定扩展名的文件名，保存到数组里。
my @list = grep {/$Ext$/ && -f "$Dir/$_" } readdir(DH) ;
closedir(DH) ;
chdir($Dir) or die "Can't cd dir: $!\n" ;
foreach my $file (@list){
    my $Basename = basename($file,($Ext));
    #my($filename, $dirs, $suffix) = fileparse($file);
    print "$Dir/$file $CWD/$Basename"."mfc\n" ;
}