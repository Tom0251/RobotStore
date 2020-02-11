import * as tslib_1 from "tslib";
import { Component } from '@angular/core';
let LoginComponent = class LoginComponent {
    constructor(service, router, toastr) {
        this.service = service;
        this.router = router;
        this.toastr = toastr;
        this.formModel = {
            UserName: '',
            Password: ''
        };
    }
    ngOnInit() {
        if (localStorage.getItem('token') != null)
            this.router.navigateByUrl('/home');
    }
    onSubmit(form) {
        this.service.login(form.value).subscribe((res) => {
            localStorage.setItem('token', res.token);
            this.router.navigateByUrl('/home');
        }, err => {
            if (err.status == 400)
                this.toastr.error('Incorrect username or password.', 'Authentication failed.');
            else
                this.toastr.error(err.description);
            console.log(err);
        });
    }
};
LoginComponent = tslib_1.__decorate([
    Component({
        selector: 'app-login',
        templateUrl: './login.component.html',
        styles: []
    })
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map