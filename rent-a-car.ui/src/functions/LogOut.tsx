export default function logOut(): boolean {
    try {
        localStorage.clear()
        return true;
    } catch (error) {
        console.error(error);
        return false;
    }
}

