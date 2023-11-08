function arrayRotation(arr, rotations) {
    let newArr = arr.slice(rotations % arr.length).concat(arr.slice(0,rotations % arr.length));

    console.log(newArr.join(" "));
}

arrayRotation([2, 4, 15, 31], 5)