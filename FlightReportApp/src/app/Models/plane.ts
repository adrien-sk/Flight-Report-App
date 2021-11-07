export class Plane {
    public id: number;
    public code: string;
    public color: string;
    public first_use_date: Date;

    constructor(id: number, code: string, color: string, first_use_date: Date) {
        this.id = id;
        this.code = code;
        this.color = color;
        this.first_use_date = first_use_date;
    }
}
