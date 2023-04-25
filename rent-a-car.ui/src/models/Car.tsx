export class Car {
    constructor(
        public id: number,
        public make: string,
        public model: string,
        public plateNumber: string,
        public dailyRate: number,
        public kind: string,
        public isAvailable: boolean
    ) { }
}