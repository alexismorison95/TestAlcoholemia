import { Component, Inject, OnInit } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-ok-snack-bar',
  templateUrl: './ok-snack-bar.component.html',
  styleUrls: ['./ok-snack-bar.component.css']
})
export class OkSnackBarComponent implements OnInit {

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: string) { }

  ngOnInit(): void {
  }

}
