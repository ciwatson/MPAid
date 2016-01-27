from distutils.core import setup
import py2exe

setup(
    console=['Runner.py']
    #options = {'py2exe': {'packages': ['encodings']}}
)
