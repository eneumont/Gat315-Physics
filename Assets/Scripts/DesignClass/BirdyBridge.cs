using System;

abstract class Birdie {
	protected BirdMaker maker1;

	protected Birdie(BirdMaker maker1) {
		this.maker1 = maker1;
	}

	abstract public void create();
}

class RedBird : Birdie {
	public RedBird(BirdMaker maker1) : base(maker1) {}

	override
	public void create() {
		Console.Write("Red ");
		maker1.make();
	}
}

class BlueBird : Birdie {
	public BlueBird(BirdMaker maker1) : base(maker1) { }

	override
	public void create() {
		Console.Write("Blue ");
		maker1.make();
	}
}

interface BirdMaker {
	abstract public void make();
}

class createBird : BirdMaker {
	public void make() {
		Console.Write(" created...");
	}
}

public class birdBridge {
	Birdie[] birds;

	public void createBirds(string[] birdList) {
		birds = new Birdie[birdList.Length];

		for (int i = 0; i < birdList.Length; i++) {
			switch (birdList[i]) {
				case "Red":
					birds[i] = new RedBird(new createBird());
					break;
				case "Blue":
					birds[i] = new BlueBird(new createBird());
					break;
			}

			birds[i].create();
		}
	}
}