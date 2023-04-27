export class MakeReservationDto {
    constructor(
        public startDate: Date | null | number | string,
        public endDate: Date | null | number | string,
        public carId?: number,
        public pickupLocationId?: number,
        public dropoffLocationId?: number,
        public userId?: number
    ) { }
}