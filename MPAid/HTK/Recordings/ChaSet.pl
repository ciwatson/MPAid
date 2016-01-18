#!/usr/bin/perl
use warnings;
use strict;
use Encode;

my @charsets = qw(utf-8 latin1 iso-8859-1 iso-8859-15 utf-16);

# some non-ASCII codepoints:
my $test = 'kë: kï'. "\n";

for (@charsets){
    print "$_: " . encode($_, $test);
}