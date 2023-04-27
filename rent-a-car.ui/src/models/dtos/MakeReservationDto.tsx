export class MakeReservationDto {
    constructor(
        public startDate: Date | string,
        public endDate: Date | string,
        public carId: number,
        public pickupLocationId: number,
        public dropoffLocationId: number,
        public userId: number
    ) { }
}