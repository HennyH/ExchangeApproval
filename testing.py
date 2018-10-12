from selenium import webdriver
from selenium.webdriver.common.by import By
import unittest
import sys 
sys.path.append("..") 


class Search():
    def test_pagesearch(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(20)
        driver.get(baseURL)

        #st = Searchtest(driver)
        #st.pagetest("CIVL2121")
     
        Searchinput = driver.find_element_by_xpath("//*[@id='__table__decisions-table_filter']/label/input")
        Searchinput.send_keys("CIVL2121")

        studentdetail = driver.find_element_by_xpath("//span[contains(text(),'CIVL2121')]")
        if studentdetail is not None:
            print("Search Successful")
            driver.quit()
        else:
            print("Search failed")
            driver.quit()

    def test_addcart(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(20)
        driver.get(baseURL)

        clickbtn = driver.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[1]/td[6]/button")
        clickbtn.click()

        cart = driver.find_element_by_xpath("//*[@id='__table__datatable-1']/tbody/tr[1]/td[1]/a")
        if cart is not None:
            print("Add to cart successful")
            driver.quit()
        else:
            print("Add to cart failed")
            driver.quit()

    def test_studentapp(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(3)
        driver.get(baseURL)

        clicksa = driver.find_element_by_xpath("//*[@id='navbarNavAltMarkup']/div/a[2]")
        clicksa.click()

        detail = driver.find_element_by_xpath("//*[contains(text(),'email')]")
        if detail is not None:
            print("Go to student application successful")
            driver.quit()
        else:
            print("Go to student application failed")
            driver.quit()

    def test_staffportal(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(20)
        driver.get(baseURL)

        clicksp = driver.find_element_by_xpath("//*[@id='navbarNavAltMarkup']/div/a[3]")
        clicksp.click()

        detailsp = driver.find_element_by_xpath("//*[contains(text(),'Unit Coordinators')]")
        if detailsp is not None:
            print("Go to staff portal successful")
            driver.quit()
        else:
            print("Go to staff portal failed")
            driver.quit()

    def test_selectunit(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(20)
        driver.get(baseURL)

        addtocart = driver.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[1]/td[6]/button")
        addtocart.click()

        cartdetail = driver.find_element_by_xpath('//*[@id="__table__datatable-1"]/tbody/tr/td[3]/span/span')
        if cartdetail is not None:
            print("Select unit successful")
            driver.quit()
        else:
            print("Select unit failed")
            driver.quit()





ff =Search()
ff.test_pagesearch()
ff.test_addcart()
ff.test_studentapp()
ff.test_staffportal()
ff.test_selectunit()


