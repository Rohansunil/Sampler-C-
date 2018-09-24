import { Component, OnInit } from '@angular/core';
import { FileUploadService } from '../services/file-upload.service';

@Component({
  selector: 'app-csv-upload',
  templateUrl: './csv-upload.component.html',
  styleUrls: ['./csv-upload.component.css'],
  providers: [FileUploadService]
})
export class CsvUploadComponent implements OnInit {

  fileToUpload : File = null;
  constructor(private fileService : FileUploadService) { }

  handleFileInput(file : FileList){      

    this.fileToUpload = file.item(0);
  }

  upload(file){
    this.fileService.postFile(this.fileToUpload).subscribe(
      data =>{
        console.log('done');
      }
    );
  }
  ngOnInit() {
  }

}
