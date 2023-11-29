#include <iostream>
#include <string>
#include <vector>

#include <SDL_FullLibraries.h>
#include <GUI.h>

#include "Expression.h"

using namespace std;

const int SCREEN_WIDTH = 360;
const int SCREEN_HEIGHT = 640;

bool init();
bool loadMedia();
void close();

cWindow mainWindow;
cImage backgroundImage;

enum BUTTONS {
	//organized by the button size
	//big buttons
	BUTTON_0,
	BUTTON_1,
	BUTTON_2,
	BUTTON_3,
	BUTTON_4,
	BUTTON_5,
	BUTTON_6,
	BUTTON_7,
	BUTTON_8,
	BUTTON_9,

	BUTTON_DOT,
	BUTTON_DEL,
	BUTTON_AC,

	BUTTON_ADD,
	BUTTON_SUB,
	BUTTON_MUL,
	BUTTON_DIV,

	BUTTON_UP,
	BUTTON_DOWN,
	BUTTON_LEFT,
	BUTTON_RIGHT,

	BUTTON_EQUAL,
	BUTTON_EXP,
	BUTTON_ANS,

	//small buttons
	BUTTON_SIN,
	BUTTON_COS,
	BUTTON_TAN,
	BUTTON_HYP,
	
	BUTTON_LOG,
	BUTTON_LN,
	BUTTON_EXPONENTIAL,
	BUTTON_ROOT,

	BUTTON_OPENBRACKET,
	BUTTON_CLOSEBRACKET,

	BUTTON_SHIFT,
	BUTTON_ALPHA,

	BUTTON_TOTAL
};
enum SELECT_MODE {
	NORMAL,
	SHIFT,
	ALPHA
};
class Calculator {
public:
	static void setUp() {
		currentScreen = 0;
		showOutput = false;
		showErrorScreen = false;
	}
	static void handleInputEvent(SDL_Event& e);

	static void updateDisplayScreen();
	static void clearDisplayScreen();
	static void displayScreen();
	static void displayErrorScreen();

	static void clearMemory();
	static void loadPreviousScreen();
	static void loadNextScreen();

	static void saveData();

private:
	static inline int currentScreen;
	static inline bool showOutput;
	static inline bool showErrorScreen;

	static inline string savedInputtingScreenContent;
};

class InputtingScreen{
public:
	static void setUp() {
		//window master
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].setWindowMaster(&mainWindow);
		}
		cursorBar.setWindowMaster(&mainWindow);

		//properties
		displayDigitSize = (width) / digitOnScreen;
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].setPosition(posX + displayDigitSize *i , posY);
			displayDigit[i].setSize(displayDigitSize, 30);
			displayDigit[i].loadTextFont("Resources/inputFont.ttf");
			displayDigit[i].setWordSize(25);
			displayDigit[i].setTextColor({ 0,0,0 });
		}

		cursorBar.setSize(15, 30);
		cursorBar.loadTextFont("Resources/inputFont.ttf");
		cursorBar.setWordSize(30);
		cursorBar.setTextContent("|");
		cursorBar.setTextColor({ 0,0,0 });
		cursorBar.updateTextRenderContent();
	}

	//rendering
	static void updateRenderContent() {
		if (cursor > digitOnScreen - 1) {
			//use only 11
			if (cursor == screenContent.size()) {
				for (int i = 0; i < digitOnScreen - 1; i++) {
					displayDigit[i].setTextContent(screenContent.substr(cursor - digitOnScreen + i + 1, 1));
				}
				//last one set shit
				displayDigit[digitOnScreen - 1].setTextContent(" ");
			}
			//use all
			else {
				for (int i = 0; i < digitOnScreen; i++) {
					displayDigit[i].setTextContent(screenContent.substr(cursor - digitOnScreen + i + 1, 1));
				}
			}
			cursorBar.setPosition(posX + displayDigitSize * digitOnScreen - 25, posY);
		}
		else {
			if (screenContent.size() < digitOnScreen) {
				for (int i = 0; i < (int)screenContent.size(); i++) {
					displayDigit[i].setTextContent(screenContent.substr(i, 1));
				}
				for (int i = (int)screenContent.size(); i < digitOnScreen; i++) {
					displayDigit[i].setTextContent(" ");
				}
			}
			else {
				for (int i = 0; i < digitOnScreen; i++) {
					displayDigit[i].setTextContent(screenContent.substr(i, 1));
				}
			}
			cursorBar.setPosition(posX + displayDigitSize * cursor - 8, posY);
		}
		for (int i = 0; i < min(int(screenContent.size()), digitOnScreen); i++) {
			displayDigit[i].updateTextRenderContent();
		}
	}
	static void clearRenderContent() {
		for (int i = 0; i <digitOnScreen; i++) {
			displayDigit[i].setTextContent(" ");
			displayDigit[i].updateTextRenderContent();
		}
	}
	static void render() {
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].renderMiddle();
		}
		if (!cursorBarPhase) {		
			cursorBar.renderSketch();
		}
		if (cursorBarValue > 100) {
			cursorBarPhase = ~cursorBarPhase;
			cursorBarValue = 0;
		}
		cursorBarValue++;
	}

	//working with cursor
	static void rightShiftCursor() {
		if (cursor < screenContent.size()) {		
			for (auto it = Expression::functionHeaders.begin(); it != Expression::functionHeaders.end(); it++) {
				if (checkThereIsAPatternStartHere(screenContent, cursor, *it)) {
					cursor += (*it).size() + 1;
					return;
				}
			}
			if (checkThereIsAPatternStartHere(screenContent, cursor, "Ans")) {
				cursor += 3;
				return;
			}
			if (checkThereIsAPatternStartHere(screenContent, cursor, "pi")) {
				cursor += 2;
				return;
			}
			cursor++;
		}
		else {
			setCursorToFront();
		}
	}
	static void leftShiftCursor() {
		if (cursor > 0) {
			for (auto it = Expression::functionHeaders.begin(); it != Expression::functionHeaders.end(); it++) {
				if (checkThereIsAPatternEndHere(screenContent, cursor-1, *it +"(")) {
					cursor -= (*it).size() + 1;
					return;
				}
			}
			if (checkThereIsAPatternEndHere(screenContent, cursor - 1, "Ans")) {
				cursor -= 3;
				return;
			}
			if (checkThereIsAPatternEndHere(screenContent, cursor - 1, "pi")) {
				cursor -= 2;
				return;
			}
			cursor--;
		}
		else {
			setCursorToBack();
		}
	}
	static void setCursorToBack() {
		cursor = screenContent.size();
	}
	static void setCursorToFront() {
		cursor = 0;
	}
	//working with content
	static void insertAtCursor(string s) {
		if (cursor == screenContent.size()) {
			screenContent.append(s);
		}
		else {
			screenContent.insert(cursor, s);
		}
		rightShiftCursor();
	}
	static void eraseAtCursor() {
		if (!cursor) {
			return;
		}
		int oldCursor{ cursor };
		leftShiftCursor();
		screenContent.erase(cursor, oldCursor-cursor);
	}
	static void clearContent() {
		if (screenContent.size()) {
			screenContent.clear();
		}
		cursor = 0;
	}
	
	static void free() {
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].free();
		}
		cursorBar.free();
	}

	static void pushContentToMemory() {
		if (screenContentInMemory.size() > 4) {
			screenContentInMemory.erase(screenContentInMemory.begin());
		}
		screenContentInMemory.push_back(screenContent);
	}
	//data member
	static inline string screenContent;
	static inline int cursor;

	static inline vector<string> screenContentInMemory;
private:
	//label 
	static const int digitOnScreen{ 12 };
	static inline cLabel displayDigit[digitOnScreen];
	static inline int displayDigitSize;

	//cursor
	static inline cLabel cursorBar;
	static inline int cursorBarPhase;
	static inline Uint8 cursorBarValue;

	//inputting screen area
	static const int posX{ 77 };
	static const int posY{ 115 };
	static const int width{ 225 };
	static const int height{ 70 };
};

class OutputtingScreen {
public:
	static void setUp() {
		//window master
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].setWindowMaster(&mainWindow);
		}
		equalSign.setWindowMaster(&mainWindow);

		displayDigitSize = (width- 10) / digitOnScreen - 1;
		//position
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].setPosition(posX + displayDigitSize * i, posY);
			displayDigit[i].setSize(20, 30);
			displayDigit[i].loadTextFont("Resources/outputFont.ttf");
			displayDigit[i].setWordSize(30);
			displayDigit[i].setTextColor({ 0,0,0 });
		}

		equalSign.setPosition(posX - 15, posY);
		equalSign.setSize(10, 30);
		equalSign.loadTextFont("Resources/outputFont.ttf");
		equalSign.setWordSize(30);
		equalSign.setTextContent("=");
		equalSign.setTextColor({ 0,0,0 });

		//process extra rules
		inputExpression.addConvertingRule("x", "*");
		inputExpression.addConvertingRule("Ans", prescreenContent);
	}

	static void updateRenderContent() {
		for (int i = 0; i < min(digitOnScreen, (int)screenContent.size()); i++) {
			displayDigit[i].setTextContent(screenContent.substr(i, 1));
			displayDigit[i].updateTextRenderContent();
		}
		equalSign.setTextContent("=");
		equalSign.updateTextRenderContent();
	}
	static void clearRenderContent() {
		for (int i = 0; i < min(digitOnScreen, (int)screenContent.size()); i++) {
			displayDigit[i].setTextContent(" ");
			displayDigit[i].updateTextRenderContent();
		}
		equalSign.setTextContent(" ");
		equalSign.updateTextRenderContent();
	}
	static void render() {
		for (int i = 0; i < min(digitOnScreen, (int)screenContent.size()); i++) {
			displayDigit[i].renderMiddle();
		}
		equalSign.renderMiddle();
	}

	static bool computeInput() {
		inputExpression = InputtingScreen::screenContent;
		inputExpression.preProcess();
		
		if (!inputExpression.checkValidity()) {
			//prompt error
			return false;
		}
		double result = inputExpression.computeResult();
		string intContent = to_string((int)result);
		screenContent = to_string(result);
		//cout << screenContent;
		if (!screenContent.size()) {
			return true;
		}
		//clean result
		if (intContent != screenContent) {
			while (screenContent.back() == '0') {
				screenContent.pop_back();
			}
			if (screenContent.back() == '.') {
				screenContent.pop_back();
			}
			if (screenContent.size() > 10) {
				screenContent = screenContent.substr(0, 10);
			}
		}	
		prescreenContent = screenContent;
		return true;
	}
	static void clearContent() {
		if (screenContent.size()) {
			screenContent.clear();
		}
	}
	static void free() {
		for (int i = 0; i < digitOnScreen; i++) {
			displayDigit[i].free();
		}
		equalSign.free();
	}

	static void pushContentToMemory() {
		if (screenContentInMemory.size() > 4) {
			screenContentInMemory.erase(screenContentInMemory.begin());
		}
		screenContentInMemory.push_back(screenContent);
	}

	static inline string screenContent;
	static inline string prescreenContent;

	static inline vector<string> screenContentInMemory;
private:
	static inline Expression inputExpression;
	//labels
	static const int digitOnScreen{ 11 };
	static inline cLabel displayDigit[digitOnScreen];
	static inline int displayDigitSize;
	//equal sign
	static inline cLabel equalSign;

	//outputting screen area
	static const int posX{ 100 };
	static const int posY{ 145 };
	static const int width{ 225 };
	static const int height{ 70 };
};

cButton gButtons[BUTTON_TOTAL];
string output;
SELECT_MODE selectMode{ NORMAL };

int main(int argc, char** argv) {
	if (!init())
	{
		printf("Failed to initialize!\n");
		return 0;
	}
	if (!loadMedia()) {
		printf("Failed to load media!\n");
		return 0;
	}

	bool quit{ false };
	SDL_Event e;
	while (!quit) {
		while (SDL_PollEvent(&e)) {
			if (e.type == SDL_WINDOWEVENT) {
				mainWindow.handleEvent(e);
			}
			if (e.type == SDL_MOUSEBUTTONDOWN) {
				Calculator::handleInputEvent(e);
				int x, y;
				SDL_GetMouseState(&x, &y);
				output.append(to_string(x) + ' ' + to_string(y) + '\n');
			}

		}

		if (!mainWindow.isMinimized()) {
			mainWindow.clearRenderContent();

			backgroundImage.render();

			Calculator::clearDisplayScreen();
			Calculator::updateDisplayScreen();
			Calculator::displayScreen();

			/*
			for (int i = 0; i < BUTTON_TOTAL; i++) {
				gButtons[i].fakeRender();
			}
			*/
			mainWindow.showRenderContent();
		}
		if (!mainWindow.isShown()) {
			quit = true;
		}
	}
	cout << output;
	close();
	return 0;
}

bool init() {
	if (!InitAll_SDLSubSystem()) {
		cout << "SDL initialized unsucessfully!";
	}
	if (!mainWindow.init("Calculator",SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL_WINDOW_SHOWN)) {
		cout << "Main window initialized unsucessfully!";
		return false;
	}
	return true;
}
bool loadMedia() {
	backgroundImage.setWindowMaster(&mainWindow);
	for (int i = 0; i < BUTTON_TOTAL; i++) {
		gButtons[i].setWindowMaster(&mainWindow);
	}
	if (!backgroundImage.loadTextureFromFile("Resources/calculatorImage.png")) {
		return false;
	}
	backgroundImage.setPosition(0, 0);
	backgroundImage.setSize(SCREEN_WIDTH, SCREEN_HEIGHT);
	
	gButtons[BUTTON_EQUAL].setPosition(258, 570);

	gButtons[BUTTON_0].setPosition(65,570);
	gButtons[BUTTON_1].setPosition(65,525);
	gButtons[BUTTON_2].setPosition(110,525);
	gButtons[BUTTON_3].setPosition(160,525);
	gButtons[BUTTON_4].setPosition(65,480);
	gButtons[BUTTON_5].setPosition(110,480);
	gButtons[BUTTON_6].setPosition(160,480);
	gButtons[BUTTON_7].setPosition(65,435);
	gButtons[BUTTON_8].setPosition(110, 435);
	gButtons[BUTTON_9].setPosition(160, 435);

	gButtons[BUTTON_ADD].setPosition(210, 525);
	gButtons[BUTTON_SUB].setPosition(260, 525);
	gButtons[BUTTON_MUL].setPosition(210, 480);
	gButtons[BUTTON_DIV].setPosition(260, 480);

	gButtons[BUTTON_UP].setPosition(170, 213);
	gButtons[BUTTON_DOWN].setPosition(170, 273);
	gButtons[BUTTON_LEFT].setPosition(137, 230);
	gButtons[BUTTON_RIGHT].setPosition(190, 230);

	gButtons[BUTTON_DOT].setPosition(110, 570);
	gButtons[BUTTON_DEL].setPosition(210, 435);
	gButtons[BUTTON_AC].setPosition(260, 435);

	gButtons[BUTTON_EXP].setPosition(160, 570);
	gButtons[BUTTON_ANS].setPosition(210, 570);

	gButtons[BUTTON_HYP].setPosition(145, 350);
	gButtons[BUTTON_SIN].setPosition(185, 350);
	gButtons[BUTTON_COS].setPosition(225, 350);
	gButtons[BUTTON_TAN].setPosition(265, 350);

	gButtons[BUTTON_LOG].setPosition(225, 310);
	gButtons[BUTTON_LN].setPosition(265, 310);
	gButtons[BUTTON_EXPONENTIAL].setPosition(185, 310);
	gButtons[BUTTON_ROOT].setPosition(105, 310);

	gButtons[BUTTON_OPENBRACKET].setPosition(145, 390);
	gButtons[BUTTON_CLOSEBRACKET].setPosition(185, 390);

	gButtons[BUTTON_SHIFT].setPosition(60, 225);
	gButtons[BUTTON_ALPHA].setPosition(100, 225);
	for (int i = 0; i < BUTTON_HYP; i++) {
		gButtons[i].setSize(40, 25);
	}
	for (int i = BUTTON_SIN; i < BUTTON_TOTAL; i++) {
		gButtons[i].setSize(30, 20);
	}
	InputtingScreen::setUp();
	OutputtingScreen::setUp();
	return true;
}
void close() {
	InputtingScreen::free();
	OutputtingScreen::free();

	CloseAll_SDLSubSystem();
}

void Calculator::handleInputEvent(SDL_Event& e)
{
	//controller button
	if (showErrorScreen) {
		if (gButtons[BUTTON_AC].checkMouseInside()) {
			clearMemory();
			clearDisplayScreen();
			showOutput = false;
			showErrorScreen = false;

			InputtingScreen::screenContent = savedInputtingScreenContent;
		}
		return;
	}
	if (gButtons[BUTTON_EQUAL].checkMouseInside()) {
		
		if (!OutputtingScreen::computeInput()) {
			Calculator::displayErrorScreen();		
		}
		else {
			OutputtingScreen::updateRenderContent();
			Calculator::showOutput = true;
			Calculator::saveData();
		}
	}
	else if (gButtons[BUTTON_DEL].checkMouseInside()) {
		InputtingScreen::eraseAtCursor();
	}
	else if (gButtons[BUTTON_AC].checkMouseInside()) {
		Calculator::clearMemory();
		Calculator::clearDisplayScreen();
		Calculator::showOutput = false;
	}

	//directional
	else if (gButtons[BUTTON_UP].checkMouseInside()) {
		Calculator::loadPreviousScreen();
	}
	else if (gButtons[BUTTON_DOWN].checkMouseInside()) {
		Calculator::loadNextScreen();
	}
	else if (gButtons[BUTTON_LEFT].checkMouseInside()) {
		InputtingScreen::leftShiftCursor();
	}
	else if (gButtons[BUTTON_RIGHT].checkMouseInside()) {
		InputtingScreen::rightShiftCursor();
	}
	//insertAtCursoring button
	else if (gButtons[BUTTON_0].checkMouseInside()) {
		InputtingScreen::insertAtCursor("0");
	}
	else if (gButtons[BUTTON_1].checkMouseInside()) {
		InputtingScreen::insertAtCursor("1");
	}
	else if (gButtons[BUTTON_2].checkMouseInside()) {
		InputtingScreen::insertAtCursor("2");
	}
	else if (gButtons[BUTTON_3].checkMouseInside()) {
		InputtingScreen::insertAtCursor("3");
	}
	else if (gButtons[BUTTON_4].checkMouseInside()) {
		InputtingScreen::insertAtCursor("4");
	}
	else if (gButtons[BUTTON_5].checkMouseInside()) {
		InputtingScreen::insertAtCursor("5");
	}
	else if (gButtons[BUTTON_6].checkMouseInside()) {
		InputtingScreen::insertAtCursor("6");
	}
	else if (gButtons[BUTTON_7].checkMouseInside()) {
		InputtingScreen::insertAtCursor("7");
	}
	else if (gButtons[BUTTON_8].checkMouseInside()) {
		InputtingScreen::insertAtCursor("8");
	}
	else if (gButtons[BUTTON_9].checkMouseInside()) {
		InputtingScreen::insertAtCursor("9");
	}

	else if (gButtons[BUTTON_DOT].checkMouseInside()) {
		InputtingScreen::insertAtCursor(".");
	}
	else if (gButtons[BUTTON_ANS].checkMouseInside()) {
		InputtingScreen::insertAtCursor("Ans");
	}
	else if (gButtons[BUTTON_EXP].checkMouseInside()) {
		if (selectMode == NORMAL) {
			InputtingScreen::insertAtCursor("e");
		}
		else if (selectMode == SHIFT) {
			InputtingScreen::insertAtCursor("pi");
		}
	}
	else if (gButtons[BUTTON_ADD].checkMouseInside()) {
		InputtingScreen::insertAtCursor("+");
	}
	else if (gButtons[BUTTON_SUB].checkMouseInside()) {
		InputtingScreen::insertAtCursor("-");
	}
	else if (gButtons[BUTTON_MUL].checkMouseInside()) {
		InputtingScreen::insertAtCursor("x");
	}
	else if (gButtons[BUTTON_DIV].checkMouseInside()) {
		InputtingScreen::insertAtCursor("/");
	}

	else if (gButtons[BUTTON_OPENBRACKET].checkMouseInside()) {
		InputtingScreen::insertAtCursor("(");
	}
	else if (gButtons[BUTTON_CLOSEBRACKET].checkMouseInside()) {
		InputtingScreen::insertAtCursor(")");
	}

	else if (gButtons[BUTTON_SIN].checkMouseInside()) {
		InputtingScreen::insertAtCursor("sin()");
	}
	else if (gButtons[BUTTON_COS].checkMouseInside()) {
		InputtingScreen::insertAtCursor("cos()");
	}
	else if (gButtons[BUTTON_TAN].checkMouseInside()) {
		InputtingScreen::insertAtCursor("tan()");
	}
	else if (gButtons[BUTTON_HYP].checkMouseInside()) {
		InputtingScreen::insertAtCursor("hyp()");
	}
	else if (gButtons[BUTTON_LOG].checkMouseInside()) {
		InputtingScreen::insertAtCursor("log()");
	}
	else if (gButtons[BUTTON_LN].checkMouseInside()) {
		InputtingScreen::insertAtCursor("ln()");
	}
	else if (gButtons[BUTTON_EXPONENTIAL].checkMouseInside()) {
		InputtingScreen::insertAtCursor("^");
	}
	else if (gButtons[BUTTON_ROOT].checkMouseInside()) {
		InputtingScreen::insertAtCursor("sqrt()");
	}
	else if (gButtons[BUTTON_SHIFT].checkMouseInside()) {
		if (selectMode == SHIFT) {
			selectMode = NORMAL;
			cout << "HI";
		}
		else {
			selectMode = SHIFT;
		}
	}
	else if (gButtons[BUTTON_ALPHA].checkMouseInside()) {
		if (selectMode == ALPHA) {
			selectMode = NORMAL;
		}
		else {
			selectMode = ALPHA;
		}
	}
}

void Calculator::updateDisplayScreen()
{
	InputtingScreen::updateRenderContent();
	if (showOutput) {
		OutputtingScreen::updateRenderContent();
	}
	
}
void Calculator::clearDisplayScreen()
{
	InputtingScreen::clearRenderContent();
	if (showOutput) {
		OutputtingScreen::clearRenderContent();
	}	
}
void Calculator::displayScreen()
{
	InputtingScreen::render();
	if (showOutput) {
		OutputtingScreen::render();
	}
	
}
void Calculator::displayErrorScreen()
{
	savedInputtingScreenContent = InputtingScreen::screenContent;
	InputtingScreen::screenContent = "SYNTAX ERROR";
	InputtingScreen::setCursorToFront();
	OutputtingScreen::screenContent = "BREAK: AC";
	showOutput = true;
	showErrorScreen = true;
}
void Calculator::clearMemory()
{
	InputtingScreen::clearContent();
	OutputtingScreen::clearContent();
}

void Calculator::loadPreviousScreen()
{
	if (!InputtingScreen::screenContentInMemory.size()) {
		return;
	}
	if (currentScreen > 0) {
		currentScreen--;
		InputtingScreen::screenContent = InputtingScreen::screenContentInMemory[currentScreen];
		OutputtingScreen::screenContent = OutputtingScreen::screenContentInMemory[currentScreen];

		InputtingScreen::setCursorToFront();
		showOutput = true;
	}
}
void Calculator::loadNextScreen()
{
	if (!InputtingScreen::screenContentInMemory.size()) {
		return;
	}
	if (currentScreen < InputtingScreen::screenContentInMemory.size()-1) {
		currentScreen++;
		InputtingScreen::screenContent = InputtingScreen::screenContentInMemory[currentScreen];
		OutputtingScreen::screenContent = OutputtingScreen::screenContentInMemory[currentScreen];

		InputtingScreen::setCursorToFront();
		showOutput = true;
	}
}
void Calculator::saveData()
{
	InputtingScreen::pushContentToMemory();
	OutputtingScreen::pushContentToMemory();
	currentScreen = InputtingScreen::screenContentInMemory.size() - 1;
}