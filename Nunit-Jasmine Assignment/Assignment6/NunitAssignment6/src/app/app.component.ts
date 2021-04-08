import { OnInit } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'NunitAssignment6';

  text: string = '1';

  ngOnInit(): void {
    this.click();
  }

  click() {
    setTimeout(() => {
      this.text += '1';
    }, 1000);
  }
}

