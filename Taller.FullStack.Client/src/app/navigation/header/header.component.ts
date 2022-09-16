import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  @Input() public fixedInViewport!: boolean;
  @Output() public sidenavToggle = new EventEmitter();

  version = environment.apiServer

  constructor() { }

  ngOnInit(): void {
  }

  public onToggleSidenav = () => {
    if (!this.fixedInViewport) {
      this.sidenavToggle.emit();
    }
  }

}
