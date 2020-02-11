import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Const } from './const';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RobotService {
  constants: Const;


  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.constants = new Const();
  }

  formModel = this.fb.group({
    Designation: ['', Validators.required],
    Price: ['', Validators.required],
    Image: ['']
  });

  GetRobots() {
    return this.http.get(this.constants.BaseURI + '/Robots');
  }

  register() {
    var re = /./gi;
    var price = this.formModel.value.Price.toString();
    var priceConvert = price.replace(".", ",");
    var body = {
      designation: this.formModel.value.Designation,
      price: priceConvert,
      files: this.upload(this.formModel.value.Image)
    };
    return this.http.post(this.constants.BaseURI + '/Robots/Register', body);
  }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (let file of files)
      formData.append(file.name, file);

    return formData;
  };

  DeleteRobot(id: string) {
    return this.http.delete(this.constants.BaseURI + '/Robots/' + id);
  }
}
