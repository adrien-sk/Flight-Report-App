export class Plane {
    public id: number;
    public code: string;
    public first_use_date: Date;

    constructor(id: number, code: string, first_use_date: Date) {
        this.id = id;
        this.code = code;
        this.first_use_date = first_use_date;
    }
}
