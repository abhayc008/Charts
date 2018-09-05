import { Component, NgModule , OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder,FormsModule, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

//   loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor( 
    //private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService) { }

    ngOnInit(){

       // reset login status
       this.authenticationService.logout();

      // get return url from route parameters or default to '/'
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        
    }

    username : string
    password : string

  login() :  void {

        
    if('test' == 'test'){

        this.authenticationService.login(this.username, this.password)
            .pipe(first())
            .subscribe(
                data => {
                   // this.router.navigate([this.returnUrl]);
                   this.router.navigate(['/nav']);
                },
                error => {
                    this.error = error;
                    this.loading = false;
                    alert(JSON.stringify(this.error));
                });     
    }else {
      alert("Invalid credentials");
    }
  }

//   ngOnInit() {
//         this.loginForm = this.formBuilder.group({
//           username: ['', Validators.required],
//           password: ['', Validators.required]
//       });

//       // reset login status
//       this.authenticationService.logout();

//       // get return url from route parameters or default to '/'
//       this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
//       }


//       // convenience getter for easy access to form fields
//       get f() { return this.loginForm.controls; }

//       onSubmit() {
//         this.submitted = true;

//         // stop here if form is invalid
//         if (this.loginForm.invalid) {
//             return;
//         }

//         this.loading = true;
//         this.authenticationService.login(this.f.username.value, this.f.password.value)
//             .pipe(first())
//             .subscribe(
//                 data => {
//                     this.router.navigate([this.returnUrl]);
//                 },
//                 error => {
//                     this.error = error;
//                     this.loading = false;
//                 });
//     }

}
