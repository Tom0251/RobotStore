import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RobotService } from 'src/app/shared/robot.service';
import { Router } from '@angular/router';
import { Robot } from 'src/app/shared/robot.model';

@Component({
  selector: 'app-robot',
  templateUrl: './robot.component.html',
  styleUrls: []
})
export class RobotComponent implements OnInit {

  constructor(public service: RobotService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (data: Robot) => {
        this.service.formModel.reset();
        this.toastr.success('New robot created!', 'Creation successful.');
        this.router.navigateByUrl('/home');
      },
      error => {
        this.toastr.error(error.description, 'Creation failed.');
        console.log(error);
      }
    )
  }
}
