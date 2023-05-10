function FormModel(){
    this.keywords = ko.observable('');
    this.domain = ko.observable('infotrack.com');
}

ko.applyBindings(new FormModel());
