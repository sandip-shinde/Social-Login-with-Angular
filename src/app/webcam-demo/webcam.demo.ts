import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {WebcamModule} from 'ngx-webcam';
import { WebcamDemoComponent } from "./webcam.demo.component";


@NgModule({
  declarations: [
    WebcamDemoComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    WebcamModule
  ],
  providers: [],
  bootstrap: [WebcamDemoComponent]
})
export class WebcamDemo {
}