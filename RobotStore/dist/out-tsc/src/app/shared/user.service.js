import * as tslib_1 from "tslib";
import { Injectable } from '@angular/core';
import { Validators } from '@angular/forms';
let UserService = class UserService {
    constructor(fb, http) {
        this.fb = fb;
        this.http = http;
        this.BaseURI = 'http://localhost:54299/api';
        this.formModel = this.fb.group({
            UserName: ['', Validators.required],
            Email: ['', Validators.email],
            FullName: [''],
            Passwords: this.fb.group({
                Password: ['', [Validators.required, Validators.minLength(4)]],
                ConfirmPassword: ['', Validators.required]
            }, { validator: this.comparePasswords })
        });
    }
    comparePasswords(fb) {
        let confirmPswrdCtrl = fb.get('ConfirmPassword');
        //passwordMismatch
        //confirmPswrdCtrl.errors={passwordMismatch:true}
        if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
            if (fb.get('Password').value != confirmPswrdCtrl.value)
                confirmPswrdCtrl.setErrors({ passwordMismatch: true });
            else
                confirmPswrdCtrl.setErrors(null);
        }
    }
    register() {
        var body = {
            UserName: this.formModel.value.UserName,
            Email: this.formModel.value.Email,
            FullName: this.formModel.value.FullName,
            Password: this.formModel.value.Passwords.Password
        };
        return this.http.post(this.BaseURI + '/user/register', body);
    }
    login(formData) {
        var body = {
            UserName: formData.value.UserName,
            Password: formData.value.Password
        };
        return this.http.post(this.BaseURI + '/user/login', body);
    }
};
UserService = tslib_1.__decorate([
    Injectable({
        providedIn: 'root'
    })
], UserService);
export { UserService };
//# sourceMappingURL=user.service.js.map