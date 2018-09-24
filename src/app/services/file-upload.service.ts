import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})

export class FileUploadService {

  constructor(private http : HttpClient) { }

  postFile(fileToUpload : File){
    const endpoint = 'http://localhost:49819/api/fileupload';
    const formData : FormData = new FormData();
    formData.append('file', fileToUpload);  
    return this.http
        .post(endpoint, formData);

  }
}
