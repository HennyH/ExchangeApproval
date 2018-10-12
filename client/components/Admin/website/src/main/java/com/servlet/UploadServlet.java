package com.servlet;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.UUID;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.fileupload.FileItem;
import org.apache.commons.fileupload.FileUploadBase.FileSizeLimitExceededException;
import org.apache.commons.fileupload.ProgressListener;
import org.apache.commons.fileupload.disk.DiskFileItemFactory;
import org.apache.commons.fileupload.servlet.ServletFileUpload;


public class UploadServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;


    // set default filename
    private String Ext_Name = "csv,doc";

    /**
     * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse
     *      response)
     */
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {


        // 
        String savePath = this.getServletContext().getRealPath("WEB-INF/upload");
        File saveFileDir = new File(savePath);
        if (!saveFileDir.exists()) {
            // create tem dir
            saveFileDir.mkdirs();
        }

        // 
        String tmpPath = this.getServletContext().getRealPath("WEB-INF/tem");
        File tmpFile = new File(tmpPath);
        if (!tmpFile.exists()) {
           
            tmpFile.mkdirs();
        }

        
        String message = "";
        try {
            
            DiskFileItemFactory factory = new DiskFileItemFactory();
            
            factory.setSizeThreshold(1024 * 10);
          
            factory.setRepository(tmpFile);
            
            ServletFileUpload upload = new ServletFileUpload(factory);
          
            upload.setProgressListener(new ProgressListener() {

                @Override
                public void update(long readedBytes, long totalBytes, int currentItem) {
                    // TODO Auto-generated method stub
                    System.out.println("Loading：" + readedBytes + "-----------file size：" + totalBytes + "--" + currentItem);
                }
            });
            
            upload.setHeaderEncoding("UTF-8");
           
            if (!ServletFileUpload.isMultipartContent(request)) {
             
                return;
            }

            // set upload file size
            upload.setFileSizeMax(1024 * 1024 * 1);// 1M
           
            upload.setSizeMax(1024 * 1024 * 10);// 10M

            List items = upload.parseRequest(request);
            Iterator itr = items.iterator();
            while (itr.hasNext()) {
                FileItem item = (FileItem) itr.next();
                
                if (item.isFormField()) {
                    String name = item.getFieldName();
                 
                    String value = item.getString("UTF-8");
                    // value = new String(value.getBytes("iso8859-1"),"UTF-8");
                    System.out.println(name + "=" + value);
                } else/
                {
                    
                    String fileName = item.getName();
                    System.out.println("filenaeme：" + fileName);
                    if (fileName == null && fileName.trim().length() == 0) {
                        continue;
                    }
                
                    fileName = fileName.substring(fileName.lastIndexOf("\\") + 1);

                    String fileExt = fileName.substring(fileName.lastIndexOf(".") + 1).toLowerCase();
                   
                    System.out.println("The file name is：" + fileExt);
                    if(!Ext_Name.contains(fileExt)){
                        System.out.println("Not right file:" + fileExt);
                        message = message + "file：" + fileName + "，not right file：" + fileExt + "<br/>";
                        break;
                    }

                    // check file size
                    if(item.getSize() == 0) continue;
                    if(item.getSize() > 1024 * 1024 * 1){
                        System.out.println("file size：" + item.getSize());
                        message = message + "file：" + fileName + "，is over size：" + upload.getFileSizeMax() + "<br/>";
                        break;
                    }


                
                    String saveFileName = makeFileName(fileName);

                    InputStream is = item.getInputStream();
                    
                    FileOutputStream out = new FileOutputStream(savePath + "\\" + saveFileName);
                 
                    byte buffer[] = new byte[1024];
                    
                    int len = 0;
                    while((len = is.read(buffer)) > 0){
                        out.write(buffer, 0, len);
                    }
                   
                    out.close();
                   
                    is.close();
                    
                    item.delete();

                    message = message + "file：" + fileName + "，upload successful<br/>";

                }
            }
        } catch (FileSizeLimitExceededException e) {
            message = message + "is over size<br/>";
            e.printStackTrace();
        } catch (Exception e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } finally {
            request.setAttribute("message", message);
            request.getRequestDispatcher("/message.jsp").forward(request, response);
        }
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

    private String makeFileName(String fileName) {
        return UUID.randomUUID().toString().replaceAll("-", "") + "_" + fileName;

    }


}