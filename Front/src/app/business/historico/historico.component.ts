import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { BusinessService } from 'app/config/business.service';

@Component({
    selector: 'app-historico',
    templateUrl: './historico.component.html',
    styleUrls: ['./historico.component.scss']
})

export class HistoricoComponent implements OnInit {

    facturaSeleccionada = {};
    facturas = [];
    canSubmit = false;

    constructor(private backend: BusinessService, private modalService: NgbModal) { }

    ngOnInit() {
        this.backend.getFacturas().then((data: []) => {
            this.facturas = data;
            this.canSubmit = true;
        });
    }

    openModal(content, factura) {
        this.facturaSeleccionada = factura;
        this.modalService.open(content, { size: 'lg', ariaLabelledBy: 'modal-basic-title' });
    }

}
