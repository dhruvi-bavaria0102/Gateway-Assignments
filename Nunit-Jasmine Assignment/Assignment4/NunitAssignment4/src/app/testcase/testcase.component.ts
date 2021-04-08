import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-testcase',
  templateUrl: './testcase.component.html',
  styleUrls: ['./testcase.component.css']
})
export class TestcaseComponent implements OnInit {

  constructor() { }
  public addition(data) {
    return data + 10;
}

public sub(data) {
    return data - 10;
}

public mul(data) {
    return data * 5;
}

public div(data) {
    return data / 10;
}

public sqr(id) {
  return id * id;
}


  ngOnInit(): void {
  }

}
