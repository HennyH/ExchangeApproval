
from selenium import webdriver
from time import sleep

#Open chrome
browser = webdriver.Chrome()
#URL
browser.get('https://exchange-approval-production.herokuapp.com/#!/search')

browser.maximize_window()

sleep(2)
#Find search bar
browser.find_element_by_xpath("//*[@class='select2-search__field']").send_keys("Mcmaster University")

sleep(2)
#click on "search" button
browser.find_element_by_xpath("//*[@class='btn btn-primary']").click()

sleep(2)
#go student application page
browser.find_element_by_xpath("//*[@id='navbarNavAltMarkup']/div/a[2]").click()

sleep(2)
#go staff portal
browser.find_element_by_xpath("//*[@id='navbarNavAltMarkup']/div/a[3]").click()

sleep(2)
#go back to search units
browser.find_element_by_xpath("//*[@id='navbarNavAltMarkup']/div/a[1]").click()

sleep(2)
#Click on university name
browser.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[1]/td[2]/a").click()

sleep(2)
#back
browser.back()

sleep(2)
#click on add to cart button
browser.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[1]/td[6]/button").click()

sleep(1)
browser.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[5]/td[6]/button").click()
sleep(1)
browser.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[8]/td[6]/button").click()

sleep(2)
#delete units has seleted
browser.find_element_by_xpath("//*[@id='__table__datatable-1']/tbody/tr[1]/td[4]/button").click()
sleep(1)
browser.find_element_by_xpath("//*[@id='__table__datatable-1']/tbody/tr[3]/td[4]/button").click()
sleep(1)
browser.find_element_by_xpath("//*[@id='__table__datatable-1']/tbody/tr[2]/td[4]/button").click()
sleep(1)
browser.find_element_by_xpath("//*[@id='__table__datatable-1']/tbody/tr[1]/td[4]/button").click()

sleep(2)
#click on unit information
browser.find_element_by_xpath("//*[@id='__table__decisions-table']/tbody/tr[1]/td[4]/span/a").click()

sleep(2)
browser.back()

sleep(2)
#click on next page button
browser.find_element_by_xpath("//*[@id='__table__decisions-table_next']/a").click()

sleep(2)
#again
browser.find_element_by_xpath("//*[@id='__table__decisions-table_next']/a").click()

sleep(2)
#click on No.60 page
browser.find_element_by_xpath("//*[@id='__table__decisions-table_paginate']/ul/li[8]/a").click()

sleep(2)
#click on previous page button
browser.find_element_by_xpath("//*[@id='__table__decisions-table_previous']/a").click()

sleep(2)
#again
browser.find_element_by_xpath("//*[@id='__table__decisions-table_previous']/a").click()

sleep(2)
#back to first page
browser.find_element_by_xpath("//*[@id='__table__decisions-table_paginate']/ul/li[2]/a").click()

sleep(2)
#search Elevtive units
browser.find_element_by_xpath("//*[@id='__table__decisions-table_filter']/label/input").send_keys("Elevtive")
