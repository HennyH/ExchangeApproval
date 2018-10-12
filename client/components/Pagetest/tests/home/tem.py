def test_addcart(self):
        baseURL = "https://exchange-approval-production.herokuapp.com/#!/search"
        driver = webdriver.Chrome()
        driver.maximize_window()
        driver.implicitly_wait(3)
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
        driver.implicitly_wait(3)
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