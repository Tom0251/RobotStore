import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { UserModel } from '../shared/user.model';
import { RobotService } from '../shared/robot.service';
import { ToastrService } from 'ngx-toastr';
import { Robot } from '../shared/robot.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})

export class HomeComponent implements OnInit {
  user: UserModel;
  public robots;
  title: string;
  imageToShow: any;

  constructor(private router: Router, private service: RobotService, private toastr: ToastrService) {
    this.title = 'List of Robots - RobotStore';
  }


  ngOnInit() {
    this.getUserFromLocalStorage();
    this.fectchData();
  }

  getUserFromLocalStorage() {
    this.user = new UserModel().deserialize(JSON.parse(localStorage.getItem("user")));
  }

  onLogout() {
    localStorage.clear();
    this.router.navigate(['/user/login']);
  }

  fectchData() {
    this.service.GetRobots().subscribe(
      res => {
        this.robots = res
      },
      err => {
        console.log(err);
      }
    )
    // for (let robot of this.robots) {
    //   robot.image = this.createImageFromBlob(robot.image);
    // }
  }

  addRobot() {
    this.router.navigateByUrl('/home/robot');
  }

  DeleteRobot(id: string) {
    this.service.DeleteRobot(id).subscribe(
      (data: Robot) => {
        this.service.formModel.reset();
        this.toastr.success('Robot deleted!', 'Delete successful.');
        location.reload();

      },
      error => {
        this.toastr.error(error.description, 'Delete failed.');
        console.log(error);
      }
    )

  }

  createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
      this.imageToShow = reader.result;
    }, false);

    if (image) {
      reader.readAsDataURL(image);
    }
  }
}
