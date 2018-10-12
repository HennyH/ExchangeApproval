package com.servlet;

import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.OutputStream;
import java.net.URLEncoder;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class DownloadServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        // Get the download filename
        String fileName = request.getParameter("filename"); // 2323928392489-美人鱼.avi
        fileName = new String(fileName.getBytes("iso8859-1"), "UTF-8");
        // Save uploaded file in/WEB-INF/upload
        String fileSaveRootPath = this.getServletContext().getRealPath("/WEB-INF/upload");
        // get download file
        File file = new File(fileSaveRootPath + "\\" + fileName);
        // if not exists
        if (!file.exists()) {
            request.setAttribute("message", "not exists");
            request.getRequestDispatcher("/message.jsp").forward(request, response);
            return;
        }
        // filename
        String realname = fileName.substring(fileName.indexOf("_") + 1);
        // setheader to handle the file name
        response.setHeader("content-disposition", "attachment;filename=" + URLEncoder.encode(realname, "UTF-8"));
        // read the download file and save it
        FileInputStream in = new FileInputStream(fileSaveRootPath + "\\" + fileName);
        // create output stream
        OutputStream out = response.getOutputStream();
        byte buffer[] = new byte[1024];
        int len = 0;
        // 
        while ((len = in.read(buffer)) > 0) {
            // 
            out.write(buffer, 0, len);
        }
        // 
        in.close();
        //
        out.close();

    }

    /**
     * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // TODO Auto-generated method stub
        doGet(request, response);
    }



}