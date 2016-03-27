__author__ = 'Hadar'
#region ----------   ABOUT   -----------------------------
"""
##################################################################
# Created By: Hadar Rabin                                        #
# Date: 20/03/2016                                               #
# Name: AES Encryption & Decryption Script                       #
# Version: 1.2                                                   #
# Windows Tested Versions: Win 7 64-bit                          #
# Python Tested Versions: 2.7 32-bit                             #
# Python Environment  : PyCharm                                  #
# pyCrypto Tested Versions: Python 2.7 32-bit                    #
##################################################################
"""
#endregion

#region ----------   IMPORTS   -----------------------------
from Crypto import Random
from Crypto.Cipher import AES
from base64 import b64encode,b64decode
import sys


#endregion

#region ----------   CONSTANTS   -----------------------------

# Define the block size (as AES is a block cipher encryption algorithm).
# Valid options are:
# 16 - for AES128 bit
# 24 - for AES196 bit
# 32 - for AES256 bit
BLOCK_SIZE = 16

# Your input has to fit into a block of BLOCK_SIZE.
# To make sure the last block to encrypt fits in the block, you may need to pad the input.
# This padding must later be removed after decryption so a standard padding would help.
# The idea is to separate the padding into two concerns: interrupt and then pad
# First you insert an interrupt character and then a padding character
# On decryption, first you remove the padding character until you reach the interrupt character
# and then you remove the interrupt character
INTERRUPT = u'\u0001'
PAD = u'\u0000'

#endregion

#region ----------   FUNCTION   -----------------------------

# Strip your data after decryption (with pad and interrupt_
def StripPadding(data):
    return data.rstrip(PAD).rstrip(INTERRUPT)
''' Or in one line:
StripPadding = lambda data, interrupt, pad: data.rstrip(pad).rstrip(interrupt)
'''

# Pad your data before encryption (with pad and interrupt_
def AddPadding(data):
    new_data = ''.join([data, INTERRUPT])
    new_data_len = len(new_data)
    remaining_len = BLOCK_SIZE - new_data_len
    to_pad_len = remaining_len % BLOCK_SIZE
    pad_string = PAD * to_pad_len
    return ''.join([new_data, pad_string])
''' Or in one line:
AddPadding = lambda data, interrupt, pad, block_size: ''.join([''.join([data, interrupt]), (pad * ((block_size - (len(''.join([data, interrupt])))) % block_size))])
'''


#endregion

#region ----------   CLASSES   -----------------------------

class Usage(Exception):
    def __init__(self, msg):
        self.msg = msg

class AESC:
    def __init__(self):
        self.Key = Random.new(10)
        self.AESobj = AES.new(self.Key)
    def __init__(self,secretKEY):
        self.Key = secretKEY
        self.AESobj = AES.new(secretKEY)

    # Encrypt the given data with the encryption cypher
    def encrypt_data(self,data_to_encrypt):
        try:
            plaintext_padded = AddPadding(data_to_encrypt)
            encrypted = self.AESobj.encrypt(plaintext_padded)
            return b64encode(encrypted)

            # Catch any general exception
        except Usage, err:
            print >>sys.stderr, err.msg
            print >>sys.stderr, "for help use --help"
            return None
    # Decrypt the given encrypted data with the decryption cypher
    def decrypt_data(self,encrypted_data):
        try:
            decoded_encrypted_data = b64decode(encrypted_data)
            decrypted_data = self.AESobj.decrypt(decoded_encrypted_data)
            return StripPadding(decrypted_data )
        except Usage, err:
            print >>sys.stderr, err.msg
            print >>sys.stderr, "for help use --help"
            return None
#endregion
