from selenium import webdriver
from selenium.webdriver.common.by import By
import sys 
sys.path.append("..") 

class Searchtest():
    def __init__(self,driver):
        self.driver = driver
    
    def pagetest(self,Searchinput):
           Searchinput = self.driver.find_element_by_xpath("//*[@id='__table__decisions-table_filter']/label/input")
        Searchinput.send_keys(Searchinput)


    


    