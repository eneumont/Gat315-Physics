using System;

public interface Character {
	string getName();
	string getClass();
}

public class mageCharacter : Character {
	public string getName() {
		return "This is Maddie";
	}

	public string getClass() {
		return "She is a mage";
	}
}

public abstract class characterDecorator : Character {
	protected Character c;

	public characterDecorator(Character c) {
		this.c = c;
	}

	public string getName() {
		return c.getName();
	}

	public string getClass() {
		return c.getClass();
	}
}

public class fireDecorator : characterDecorator {
	public fireDecorator(Character c) : base(c) {}

	public string getName() {
		return c.getName() + ", who is also a fire chracter";
	}

	public string getClass() {
		return c.getClass() + ", with a water weakness";
	}
}

public class wandDecorator : characterDecorator {
	public wandDecorator(Character c) : base(c) {}

	public string getName() {
		return c.getName() + ", and she uses a wand.";
	}

	public string getClass() {
		return c.getClass() + ", and she specializes in fire magic.";
	}
}