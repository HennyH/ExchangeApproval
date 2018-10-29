package god.testscripts.uwatestcase;

import god.util.DriverWait;
import god.util.GetScreenshot;
import god.util.Log;
import god.util.SetBrowserProperty;
import god.util.waitUse.ContextTab;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.Assert;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeClass;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.util.concurrent.TimeUnit;

/**
 * Created by aaron on 2018/10/22
 */
public class ResultGotoPage {
    public WebDriver driver;

    @BeforeClass
    public void BeforeClass() throws Exception {

    }

    @BeforeMethod
    public void beforeMethod() {
        driver = SetBrowserProperty.openChromeBrowser();//创建个默认最大化的谷歌浏览器
        driver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
        driver.get("https://exchange-approval-production.herokuapp.com");//open url
    }

    @Test
    public void resultGotoPage() throws Exception{
        Log.startTestCase("resultGotoPage case");
        try {
            String keywords = "University Of Southampton";
            String unitname = "CIVL5551";
            DriverWait.findElement(driver, driver.findElement(By.xpath("//ul[@class='select2-selection__rendered']/li/input"))).sendKeys(keywords);
            ContextTab.pressEnter();
            DriverWait.findElement(driver, driver.findElement(By.xpath("/html/body/div/div[1]/div/div[2]/div[2]/form/div[2]/div[3]/button"))).click();
            Thread.sleep(1000);
            DriverWait.findElement(driver,driver.findElement(By.xpath("//div[@id=\"__table__decisions-table_paginate\"]/ul/li[3]/a"))).click();
            Thread.sleep(1000);
            DriverWait.findElement(driver,driver.findElement(By.id("__table__decisions-table_previous"))).click();
            Thread.sleep(1000);
            DriverWait.findElement(driver,driver.findElement(By.xpath("//li[@id=\"__table__decisions-table_next\"]/a"))).click();
            Thread.sleep(1000);
            WebElement element = DriverWait.findElement(driver, driver.findElement(By.xpath("//table[@id=\"__table__decisions-table\"]/tbody/tr[1]/td[4]/span/span")));
            String seachresult = element.getText();
            if (seachresult.equals(unitname)) {
                Log.info("resultGotoPage success");
            } else {
                new GetScreenshot(driver, "resultGotoPage fail");
                Log.error("resultGotoPage fail");
                Assert.fail();
            }
        } catch (InterruptedException e) {
            new GetScreenshot(driver, "resultGotoPage fail");
            Log.error("resultGotoPage fail");
            Assert.fail();
        }
        Log.endTestCase("resultGotoPage case");
    }

    @AfterMethod
    public void afterMethod() {
//        driver.quit();
    }
}
