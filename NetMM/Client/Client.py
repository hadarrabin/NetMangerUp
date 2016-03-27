__author__ = 'Hadar'
import socket, time
import System.system
from System.Monitor import *
from Security.Rsa import *
from Security.Aes import *
import pickle
from base64 import *
from crypto import *
from crypto.Random import *
from crypto.Hash import SHA256
from crypto.Random.random import getrandbits, randint
from crypto.PublicKey import RSA
from crypto.Cipher.AES import AESCipher
from crypto.Random.random import getrandbits, randint
from Crypto import Random
from Crypto.Hash import SHA256
from base64 import b64encode, b64decode
import pickle

#region ----------   CONSTANTS   ---------------------------------------------------------------
SERVER_ADDRESS = '127.0.0.1'             # The default target server ip
SERVER_PORT = 6070                       # The default target server port
LEN_UNIT_BUF = 1024                      # Min len of buffer for recieve from server socket
MAX_RSA_MSG = 128                        # Maximum length of message encrypted in RSA module (pyCrypto limitation)
MAX_ENCRYPTED_MSG_SIZE = 128
END_LINE = "\r\n"                        # End of line
#endregion
#==================================================================================================
class client:
    def __init__(self):
        self.socket = socket.socket()
        self.key = Random.new().read(int(16))
        self.crypto = Crypto()
        self.Aesob = AESC(self.key)
        self.systemc = System.system()
        self.monitorc = Monitor.monitor()
    def start(self):
        self.socket.connect((SERVER_ADDRESS, SERVER_PORT))
        self.key_exchange()
        self.continues()
    def  key_exchange(self):
        #--------------------  1 ------------------------------------------------------------------------
        # --------------  Wait server Public_Key --------------------------------------------------------
        # get Pickled public key
        pickled_server_public_key = self.socket.recv(LEN_UNIT_BUF).split(END_LINE)[0]
        server_public_key = pickle.loads(pickled_server_public_key)
        # --------------  Wait server hash Public_Key ---------------------------------------------------------------------------
        # Hashing original Public_Key
        calculated_hash_server_pickled_public_key = SHA256.new(pickle.dumps(server_public_key)).hexdigest()
        declared_hash_server_pickled_public_key = b64decode( self.socket.recv(LEN_UNIT_BUF).split(END_LINE)[0] )
        if calculated_hash_server_pickled_public_key != declared_hash_server_pickled_public_key:
                    return "Not Magic"

        #--------------------  2 ------------------------------------------------------------------------
        # ------------  Send  client private key
        self.socket.send(pickle.dumps(self.crypto.private_key.exportKey()) + END_LINE)
        time.sleep(0.5)
        # -----------  send  Base64 Hash of self.crypto.private_key
        self.socket.send( b64encode(SHA256.new(pickle.dumps(self.crypto.private_key.exportKey())).hexdigest()) + END_LINE)
        time.sleep(0.5)

        #--------------------  3 ------------------------------------------------------------------------
        # -------------- Send  encrypted by server public key info containing symmetric key and hash symmetric key encrypted by client public key ---------------------
        if self.crypto.private_key.can_encrypt():
            hash_sym_key = SHA256.new(self.key).hexdigest()
            print str(hash_sym_key)
            pickle_encrypt_hash_sym_key = pickle.dumps(self.crypto.private_key.publickey().encrypt(hash_sym_key, 32))
            message = b64encode(self.key) + "#" + b64encode( pickle_encrypt_hash_sym_key )
            print message
            splitted_pickled_message = [message[i:i+MAX_ENCRYPTED_MSG_SIZE] for i in xrange(0, len(message), MAX_ENCRYPTED_MSG_SIZE)]
            #   Sending to server number of encrypted message parts
            self.socket.send(str(len(splitted_pickled_message)) + END_LINE)
            pickled_encrypted_message = ''
            for part in splitted_pickled_message:
                   part_encrypted_pickled_message = server_public_key.encrypt(part, 32)
                   pickled_part_encrypted_pickled_message = pickle.dumps(part_encrypted_pickled_message)
                   self.socket.send(pickled_part_encrypted_pickled_message + END_LINE)
                   pickled_encrypted_message += pickled_part_encrypted_pickled_message
                   time.sleep(0.5)
    def send(self,data):
        encrypted_data = self.Aesob.encrypt_data(data)
        self.socket.send(encrypted_data)

    def recieve(self):
        encrypted_data = self.socket.recv(LEN_UNIT_BUF)
        data = self.Aesob.decrypt_data(encrypted_data)
        return data

    def continues(self):
        basic_info = System.system.recieve_starting_inforamtion()
        self.send(basic_info)

