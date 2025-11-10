type User = {
  id: number | string;
  username: string;
  passwordHash: string | string[];
  status: "Locked" | "Unlocked" | "Deleted";
  email?: string;
};

function isValidUser(user: User): boolean {
  let isValidId =
    (typeof user.id === "number" && user.id > 100) ||
    (typeof user.id === "string" && user.id.length === 14);

  let isValidUsername = user.username.length >= 5 && user.username.length <= 10;

  let isValidPasswordHash =
    (typeof user.passwordHash === "string" &&
      user.passwordHash.length === 20) ||
    (Array.isArray(user.passwordHash) &&
      user.passwordHash.length === 4 &&
      user.passwordHash.every((e) => e.length === 8));

  let isValidStatus = user.status === "Locked" || user.status === "Unlocked";

    let result = (isValidId && isValidUsername && isValidPasswordHash && isValidStatus) ? true : false;

    return result;
}

console.log(isValidUser({
  id: 120,
  username: "testing",
  passwordHash: "123456-123456-123456",
  status: "Deleted",
  email: "something",
}));
console.log(isValidUser({
  id: "1234-abcd-5678",
  username: "testing",
  passwordHash: "123456-123456-123456",
  status: "Unlocked",
}));
console.log(isValidUser({
  id: "20",
  username: "testing",
  passwordHash: "123456-123456-123456",
  status: "Deleted",
  email: "something",
}));
console.log(isValidUser({
  id: 255,
  username: "Pesho",
  passwordHash: ["asdf1245", "qrqweggw", "123-4567", "98765432"],
  status: "Locked",
  email: "something",
}));
console.log(isValidUser({
  id: "qwwe-azfg-ey38",
  username: "Someone",
  passwordHash: ["qwezz8jg", "asdg-444", "12-34-56"],
  status: "Unlocked",
}));
console.log(isValidUser({
  id: 1344,
  username: "wow123",
  passwordHash: "123456-123456-1234567",
  status: "Locked",
  email: "something@abv.bg",
}));
