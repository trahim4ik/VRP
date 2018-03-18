import { Component, OnInit, HostListener, ElementRef } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  protected header: HTMLElement;
  protected sticky: number;

  constructor(protected elRef: ElementRef) { }

  ngOnInit() {
    this.header = document.getElementById('sticky-header');
    this.sticky = this.header.offsetTop;
    window.onscroll = onscroll;
  }

  @HostListener('scroll', ['$event'])
  onScroll($event: Event): void {
    if (this.elRef.nativeElement.scrollTop >= this.sticky) {
      this.header.classList.add('sticky');
    } else {
      this.header.classList.remove('sticky');
    }
  }

}
